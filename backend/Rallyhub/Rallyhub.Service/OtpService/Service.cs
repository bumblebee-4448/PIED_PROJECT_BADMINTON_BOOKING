using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Quartz;
using Rallyhub.Service.BackgroundJobService;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Rallyhub.Service.OtpService;

public class Service : IService
{
    private readonly IDistributedCache _redisCache;
    private readonly ISchedulerFactory _schedulerFactory;

    public Service(IDistributedCache redisCache, ISchedulerFactory schedulerFactory)
    {
        _redisCache = redisCache;
        _schedulerFactory = schedulerFactory;
    }

    public async Task GenerateAndSendOtpAsync<T>(string email, string actionType, T payloadData)
    {
        string antiSpamKey = $"Lock:Otp:{actionType}:{email}";
        if (await _redisCache.GetStringAsync(antiSpamKey) != null)
            throw new Exception("Bạn thao tác quá nhanh. Thử lại sau 60 giây.");
        await _redisCache.SetStringAsync(antiSpamKey, "locked", new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) });

        string otpCode = Random.Shared.Next(100000, 999999).ToString();
        var session = new { OtpCode = otpCode, ActionType = actionType, DataPayload = payloadData };

        string redisKey = $"OTP:{actionType}:{email}";
        await _redisCache.SetStringAsync(redisKey, System.Text.Json.JsonSerializer.Serialize(session), 
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });

        var scheduler = await _schedulerFactory.GetScheduler();
        var job = JobBuilder.Create<SendOtpJob>()
            .WithIdentity($"SendOtp_{actionType}_{email}_{Guid.NewGuid()}", "MailJobs")
            .UsingJobData("Email", email)
            .UsingJobData("OtpCode", otpCode)
            .Build();
        await scheduler.ScheduleJob(job, TriggerBuilder.Create().StartNow().Build());
    }

    public async Task<T> VerifyAndGetPayloadAsync<T>(string email, string inputOtp, string actionType)
    {
        string redisKey = $"OTP:{actionType}:{email}";
        string? cachedData = await _redisCache.GetStringAsync(redisKey);

        if (string.IsNullOrEmpty(cachedData))
            throw new Exception("Mã OTP đã hết hạn hoặc không tồn tại.");

        var jsonDocument = JsonDocument.Parse(cachedData);
        string savedOtp = jsonDocument.RootElement.GetProperty("OtpCode").GetString()!;

        if (savedOtp != inputOtp)
            throw new Exception("Mã OTP không chính xác.");

        var payloadElement = jsonDocument.RootElement.GetProperty("DataPayload");
        var payloadData = System.Text.Json.JsonSerializer.Deserialize<T>(payloadElement.GetRawText());
        await _redisCache.RemoveAsync(redisKey);
        return payloadData!;
    }
}