using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Quartz;
using Rallyhub.Repository;
using Rallyhub.Service.BackgroundJobService;
using Rallyhub.Service.User;
using Exception = System.Exception;

namespace Rallyhub.Service.IdentityService;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IDistributedCache _redisCache;
    private readonly ISchedulerFactory _schedulerFactory;

    public Service(AppDbContext dbContext, IDistributedCache redisCache, ISchedulerFactory schedulerFactory)
    {
        _dbContext = dbContext;
        _redisCache = redisCache;
        _schedulerFactory = schedulerFactory;
    }
    
    public async Task<string> RegisterTask(User.Request.RegisterRequest request)
    {
        if (await _dbContext.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("Email này đã được sử dụng trong hệ thống.");
        
        string antiSpamKey = $"Lock:Reg:{request.Email}";
        if (await _redisCache.GetStringAsync(antiSpamKey) != null)
            throw new Exception("Bạn thao tác quá nhanh. Thử lại sau 60 giây.");
        await _redisCache.SetStringAsync(antiSpamKey, "locked", new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) });

        string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(request.RawPassword, hashType: BCrypt.Net.HashType.SHA384);
        string otpCode = Random.Shared.Next(100000, 999999).ToString();

        var pendingUser = new PendingUserCache
        {
            Email = request.Email,
            PasswordHash = hashedPassword,
            OtpCode = otpCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        };
        
        string redisKey = $"OTP:{request.Email}";
        await _redisCache.SetStringAsync(redisKey, System.Text.Json.JsonSerializer.Serialize(pendingUser), 
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
        
        var scheduler = await _schedulerFactory.GetScheduler();
        var job = JobBuilder.Create<SendOtpJob>()
            .WithIdentity($"SendOtp_{request.Email}_{Guid.NewGuid()}", "MailJobs")
            .UsingJobData("Email", request.Email)
            .UsingJobData("OtpCode", otpCode)
            .Build();
        
        await scheduler.ScheduleJob(job, TriggerBuilder.Create().StartNow().Build());

        return "Vui lòng kiểm tra email để lấy mã OTP.";
    }

    public async Task<bool> VerifyOtp(string email, string inputOtp)
    {
        string redisKey = $"OTP:{email}";
        string? cachedData = await _redisCache.GetStringAsync(redisKey);

        if (string.IsNullOrEmpty(cachedData))
            throw new Exception("Mã OTP đã hết hạn hoặc bạn chưa yêu cầu đăng ký.");

        var pendingUser = System.Text.Json.JsonSerializer.Deserialize<PendingUserCache>(cachedData!);

        if (pendingUser!.OtpCode != inputOtp)
            throw new Exception("Mã OTP không chính xác.");

        var newUser = new Repository.Entity.User()
        { 
            Email = pendingUser.Email, 
            PasswordHash = pendingUser.PasswordHash, 
            FirstName = pendingUser.FirstName,
            LastName = pendingUser.LastName,
            PhoneNumber = pendingUser.PhoneNumber,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync();

        await _redisCache.RemoveAsync(redisKey);
        
        return true;
    }


}