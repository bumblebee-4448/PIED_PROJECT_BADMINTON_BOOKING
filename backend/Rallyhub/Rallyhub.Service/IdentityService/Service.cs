using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
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
    private readonly IHttpContextAccessor _httpAccessor;

    public Service(AppDbContext dbContext, 
        IDistributedCache redisCache, 
        IConfiguration configuration,
        JwtService.IService jwtService,
        OtpService.IService otpService,
        IHttpContextAccessor httpContextAccesso)
    {
        _dbContext = dbContext;
        _redisCache = redisCache;
        _jwtService = jwtService;
        _otpService = otpService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOption);
        configuration.GetSection(nameof(SecurityOptions)).Bind(_securityOptions);
        _httpAccessor = httpContextAccesso;
    }
    
    public async Task<string> RegisterTask(User.Request.RegisterRequest request)
    {
        var isExist = await _dbContext.Users.AnyAsync(x => x.Email == request.Email);
        if (isExist)
        {
            throw new Exception("Tài khoản đã tồn tại");
        }
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
        return "Check mail, verify otp";
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
            Role = "Customer",
            CreatedAt = DateTimeOffset.UtcNow,
        };
        _dbContext.Users.Add(newUser);

        var newCustomer = new Repository.Entity.Customer()
        {
            UserId = newUser.Id,
        };
        _dbContext.Customers.Add(newCustomer);
        
        var result = await _dbContext.SaveChangesAsync(); 
        
        if (result <= 0) throw new Exception("Fail");
        var claims = new List<Claim>
        {
            new Claim("UserId", newUser.Id.ToString()), 
            new Claim("Email", newUser.Email),
            new Claim("Role", newUser.Role), 
            new Claim(ClaimTypes.Role, newUser.Role),
            new Claim(ClaimTypes.Expired, 
                DateTimeOffset.UtcNow.AddMinutes(_jwtOption.ExpireMinutes).ToString()),
        };

        if (newUser.Role == "Owner")
        {
            var owner = _dbContext.Owners.FirstOrDefault(x => x.UserId == newUser.Id );
            if (owner != null)
            {
                claims.Add(new Claim("OwnerId", owner.Id.ToString()));
            }
        }
        if (newUser.Role == "Customer")
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.UserId == newUser.Id );
            if (customer != null)
            {
                claims.Add(new Claim("CustomerId", customer.Id.ToString()));
            }
        }
        
        var token = _jwtService.GenerateAccessToken(claims);
    
        return new Response.IdentityResponse
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

        if (user.Status == "Ban")
        {
            throw new Exception("Your account has been banned.");
        }
        var claims = new List<Claim>
        {
            new Claim("UserId", user.Id.ToString()), 
            new Claim("Email", user.Email),
            new Claim("Role", user.Role), 
            new Claim("Status", user.Status),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Expired, 
            DateTimeOffset.UtcNow.AddMinutes(_jwtOption.ExpireMinutes).ToString()),
        };

        if (user.Role == "Owner")
        {
            var owner = _dbContext.Owners.FirstOrDefault(x => x.UserId == user.Id );
            if (owner != null)
            {
                claims.Add(new Claim("OwnerId", owner.Id.ToString()));
            }
        }
        if (user.Role == "Customer")
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.UserId == user.Id );
            if (customer != null)
            {
                claims.Add(new Claim("CustomerId", customer.Id.ToString()));
            }
        }
        
        var token = _jwtService.GenerateAccessToken(claims);
    
        return new Response.IdentityResponse
        {
            AccessToken = token
        };
    }

    // public async Task<string> Logout(string token)
    // {
    //     try
    //     {
    //         var handler = new JwtSecurityTokenHandler();
    //         var jwtToken = handler.ReadJwtToken(token);
    //         var expDate = jwtToken.ValidTo;
    //         var remainingTime = expDate - DateTime.UtcNow;
    //
    //         if (remainingTime.TotalSeconds > 0)
    //         {
    //             string blacklistKey = $"Blacklist:{token}";
    //             await _redisCache.SetStringAsync(blacklistKey, "revoked", new DistributedCacheEntryOptions
    //             {
    //                 AbsoluteExpirationRelativeToNow = remainingTime
    //             });
    //         }
    //
    //         return "Success";
    //     }
    //     catch (Exception)
    //     {
    //         throw new Exception("Token không hợp lệ hoặc đã bị can thiệp.");
    //     }
    // }
    
    public async Task<string> ForgotPassword(Request.ForgotPasswordRequest request)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
        {
            throw new Exception("Email không tồn tại");
        }
        await _otpService.GenerateAndSendOtpAsync(request.Email, "ForgotPassword", user.Id.ToString());
        return "Check mail, verify otp";
    }

    public async Task<string> ResetPassword(Request.ResetPasswordRequest request)
    {
        var userId = await _otpService.VerifyAndGetPayloadAsync<string>(request.Email, request.OtpCode, "ForgotPassword");
        var userIdGuid = Guid.Parse(userId);

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userIdGuid);
        if (user == null)
            throw new Exception("Người dùng không tồn tại");
        string pepperedNewPassword = request.NewPassword + _securityOptions.Pepper;
        user.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(pepperedNewPassword, hashType: BCrypt.Net.HashType.SHA384);
        user.UpdatedAt = DateTimeOffset.UtcNow;

        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }

        return "Fail";
    }
}