using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Quartz;
using Rallyhub.Repository;
using Rallyhub.Service.BackgroundJobService;
using Rallyhub.Service.JwtService;
using Exception = System.Exception;

namespace Rallyhub.Service.IdentityService;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IDistributedCache _redisCache; // Giữ lại chỉ để dùng cho tính năng Logout
    private readonly JwtService.IService _jwtService;
    private readonly OtpService.IService _otpService;       // Khai báo chuyên gia OTP
    private readonly JwtOptions _jwtOption = new();
    private readonly SecurityOptions _securityOptions = new();

    public Service(AppDbContext dbContext, 
        IDistributedCache redisCache, 
        IConfiguration configuration,
        JwtService.IService jwtService,
        OtpService.IService otpService)
    {
        _dbContext = dbContext;
        _redisCache = redisCache;
        _jwtService = jwtService;
        _otpService = otpService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOption);
        configuration.GetSection(nameof(SecurityOptions)).Bind(_securityOptions);
    }
    
    public async Task<string> RegisterTask(User.Request.RegisterRequest request)
    {
        if (await _dbContext.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("Tài khoản đã tồn tại");

        string pepperedPassword = request.RawPassword + _securityOptions.Pepper;
        string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(pepperedPassword, hashType: BCrypt.Net.HashType.SHA384);

        var pendingUser = new PendingUserCache()
        {
            Email = request.Email,
            PasswordHash = hashedPassword,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            
        };
        
        await _otpService.GenerateAndSendOtpAsync(request.Email, "Register", pendingUser);

        return "Success";
    }
    
    public async Task<Response.IdentityResponse> VerifyOtp(string email, string inputOtp)
    {
        var pendingUser = await _otpService.VerifyAndGetPayloadAsync<PendingUserCache>(email, inputOtp, "Register");

        var newUser = new Repository.Entity.User()
        { 
            Email = pendingUser.Email, 
            PasswordHash = pendingUser.PasswordHash, 
            FirstName = pendingUser.FirstName,
            LastName = pendingUser.LastName,
            PhoneNumber = pendingUser.PhoneNumber,
            Role = "Customer", // Set mặc định để tránh lỗi NULL ở Token
            CreatedAt = DateTimeOffset.UtcNow,
        };
        
        _dbContext.Users.Add(newUser);
        var result = await _dbContext.SaveChangesAsync(); 
        
        if (result <= 0) throw new Exception("Fail");
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()), 
            new Claim(ClaimTypes.Email, newUser.Email),
            new Claim(ClaimTypes.Role, newUser.Role),
            new Claim("Role", newUser.Role) 
        };
        var token = _jwtService.GenerateAccessToken(claims);

        return new Response.IdentityResponse()
        {
            AccessToken = token
        };
    }

    public async Task<Response.IdentityResponse> Login(Request.LoginRequest request)
    {
        var user = await _dbContext.Users
            .Include(x => x.Owner)
            .FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null)
        {
            throw new Exception("Email hoặc mật khẩu không chính xác.");
        }
        
        string pepperedPassword = request.RawPassword + _securityOptions.Pepper;
        bool isPasswordValid = BCrypt.Net.BCrypt.EnhancedVerify(pepperedPassword, user.PasswordHash);
        if (!isPasswordValid)
        {
            throw new Exception("Email hoặc mật khẩu không chính xác.");
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "Customer"), 
            new Claim("Role", user.Role ?? "Customer") 
        };

        if (user.Role == "Owner")
        {
            var owner = _dbContext.Owners.FirstOrDefault(x => x.UserId == user.Id );
            if (owner != null)
            {
                claims.Add(new Claim("OwnerId", owner.Id.ToString()));
            }
        }
        
        var token = _jwtService.GenerateAccessToken(claims);
    
        return new Response.IdentityResponse
        {
            AccessToken = token
        };
    }

    public async Task<string> Logout(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var expDate = jwtToken.ValidTo;
            var remainingTime = expDate - DateTime.UtcNow;

            if (remainingTime.TotalSeconds > 0)
            {
                string blacklistKey = $"Blacklist:{token}";
                await _redisCache.SetStringAsync(blacklistKey, "revoked", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = remainingTime
                });
            }

            return "Success";
        }
        catch (Exception)
        {
            throw new Exception("Token không hợp lệ hoặc đã bị can thiệp.");
        }
    }
}