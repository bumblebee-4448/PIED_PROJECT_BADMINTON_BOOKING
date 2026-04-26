namespace Rallyhub.Service.MailService;

public static class MailTemplate
{
    public static string GenerateOtpTemplate(string email, string otpCode)
    {
        return $@"
        <div style='font-family: Arial; padding: 20px; text-align: center;'>
            <h1 style='color: #0da27d;'>RallyHub</h1>
            <h2>Xác thực tài khoản</h2>
            <p>Mã OTP của <b>{email}</b> là:</p>
            <h1 style='color: #0da27d; background: #e6f6f2; padding: 15px; border-radius: 8px; display: inline-block;'>{otpCode}</h1>
            <p>Mã này sẽ hết hạn sau 5 phút.</p>
        </div>";
    }
}