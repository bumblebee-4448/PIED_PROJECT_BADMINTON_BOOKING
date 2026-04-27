namespace Rallyhub.Service.OtpService;

public interface IService
{
    Task GenerateAndSendOtpAsync<T>(string email, string actionType, T payloadData);
    Task<T> VerifyAndGetPayloadAsync<T>(string email, string inputOtp, string actionType);
}