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
        // 1. Kiểm tra Email DB
        if (await _dbContext.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("Email này đã được sử dụng trong hệ thống.");

        // 2. Chống Spam Redis (Khóa 60s)
        string antiSpamKey = $"Lock:Reg:{request.Email}";
        if (await _redisCache.GetStringAsync(antiSpamKey) != null)
            throw new Exception("Bạn thao tác quá nhanh. Thử lại sau 60 giây.");
        await _redisCache.SetStringAsync(antiSpamKey, "locked", new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) });

        // 3. Băm mật khẩu an toàn
        string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(request.RawPassword, hashType: BCrypt.Net.HashType.SHA384);
        string otpCode = Random.Shared.Next(100000, 999999).ToString();

        // 4. Gói dữ liệu vào Redis (Sống 5 phút)
        var pendingUser = new PendingUserCache
        {
            Email = request.Email,
            PasswordHash = hashedPassword,
            Role = "Customer",
            OtpCode = otpCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber
        };
        
        string redisKey = $"OTP:{request.Email}";
        await _redisCache.SetStringAsync(redisKey, System.Text.Json.JsonSerializer.Serialize(pendingUser), 
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
        
        // 5. Gọi Quartz chạy ngầm gửi Mail
        var scheduler = await _schedulerFactory.GetScheduler();
        var job = JobBuilder.Create<SendOtpJob>()
            .WithIdentity($"SendOtp_{request.Email}_{Guid.NewGuid()}", "MailJobs")
            .UsingJobData("Email", request.Email)
            .UsingJobData("OtpCode", otpCode)
            .Build();
        
        await scheduler.ScheduleJob(job, TriggerBuilder.Create().StartNow().Build());

        return "Vui lòng kiểm tra email để lấy mã OTP.";
    }

    // API 2: XÁC THỰC VÀ LƯU DB
    public async Task<bool> VerifyOtp(string email, string inputOtp)
    {
        string redisKey = $"OTP:{email}";
        string? cachedData = await _redisCache.GetStringAsync(redisKey);

        if (string.IsNullOrEmpty(cachedData))
            throw new Exception("Mã OTP đã hết hạn hoặc bạn chưa yêu cầu đăng ký.");

        var pendingUser = System.Text.Json.JsonSerializer.Deserialize<PendingUserCache>(cachedData!);

        if (pendingUser!.OtpCode != inputOtp)
            throw new Exception("Mã OTP không chính xác.");

        // THÀNH CÔNG -> Đổ vào DB
        var newUser = new Repository.Entity.User()
        { 
            Email = pendingUser.Email, 
            PasswordHash = pendingUser.PasswordHash, 
            Role = pendingUser.Role, 
            Status = "Active",
            FirstName = pendingUser.FirstName,
            LastName = pendingUser.LastName,
            PhoneNumber = pendingUser.PhoneNumber,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync();

        // Xóa rác
        await _redisCache.RemoveAsync(redisKey);
        
        return true;
    }


}