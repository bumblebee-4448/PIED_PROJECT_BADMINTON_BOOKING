using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Quartz.Util;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Rallyhub.Service.IdentityService;
using Rallyhub.Service.JwtService;
using Exception = System.Exception;

namespace Rallyhub.Service.User;

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
    
    public async Task<string> ChangePassword(Request.ChangePasswordRequest request)
    {
        var userId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userIdGuild = Guid.Parse(userId!);
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userIdGuild);
        if (user == null)
        {
            throw new Exception("người dùng không tồn tại.");
        }
        string pepperedOldPassword = request.OldPassword + _securityOptions.Pepper;
        bool isOldPasswordValid = BCrypt.Net.BCrypt.EnhancedVerify(pepperedOldPassword, user.PasswordHash);
        if (!isOldPasswordValid)
            throw new Exception("Mật khẩu hiện tại không chính xác.");
        if (request.OldPassword == request.NewPassword)
            throw new Exception("Mật khẩu mới không được trùng với mật khẩu cũ.");

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

    public async Task UpdateProfile(Request.UpdateProfile request)
    {
        var getUserId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userId = Guid.Parse(getUserId!);
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        user!.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;
        user.AvatarUrl = request.AvatarUrl;
        user.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Response.UserDto> GetMe()
    {
        var getUserId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userId = Guid.Parse(getUserId!);
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("không tìm thấy user");
        }
        var owner = await _dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (user.Role == Enum.Enum.Role.Owner.ToString())
        {
            return new Response.OwnerDto()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = (user.PhoneNumber == null ? "": user.PhoneNumber),
                AvatarUrl = user.AvatarUrl,
                BusinessName = owner!.BusinessName,
                BusinessAddress = owner.BusinessAddress,
                TaxCode = owner.TaxCode,
                BusinessLicenseUrl = owner.BusinessLicenseUrl,
                IdentityCardBackUrl = owner.IdentityCardBackUrl,
                IdentityCardFrontUrl = owner.IdentityCardFrontUrl,
                IdentityNumber = owner.IdentityNumber,
            };
        }
        return new Response.UserDto()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = (user.PhoneNumber == null ? "": user.PhoneNumber),
            AvatarUrl = user.AvatarUrl,
        };
    }

    public async Task CreateWallet(Request.CreateAndUpdateWalletRequest request)
    {
        var getUserId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userId = Guid.Parse(getUserId!);
        var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == userId);
        if (wallet != null)
        {
            throw new Exception("Ví đã tồn tại");
        }
        var userWallet = new Repository.Entity.Wallet()
        {
            UserId = userId,
            BankName =  request.BankName,
            BankAccount =  request.BankAccount,
            Balance = 0,
            CreatedAt = DateTimeOffset.UtcNow,
        };
        await _dbContext.Wallets.AddAsync(userWallet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateWallet(Request.CreateAndUpdateWalletRequest request)
    {
        var getUserId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userId = Guid.Parse(getUserId!);
        var wallet = await _dbContext.Wallets.FirstOrDefaultAsync(x => x.UserId == userId);
        if (wallet == null)
        {
            throw new Exception("Ví chưa được tạo");
        }
        wallet.BankName = request.BankName;
        wallet.BankAccount = request.BankAccount;
        wallet.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Wallets.Update(wallet);
        await _dbContext.SaveChangesAsync();
    }
}