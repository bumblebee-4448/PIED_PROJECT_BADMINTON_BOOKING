namespace Rallyhub.Service.MailService;

public class MailTemplate
{
    private static string GetMainLayout(string content)
    {
        return $@"
        <!DOCTYPE html>
        <html>
        <body style='font-family: Arial, sans-serif; background-color: #f4f7f6; margin: 0; padding: 20px;'>
            <table width='100%' cellpadding='0' cellspacing='0' style='max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 10px rgba(0,0,0,0.05);'>
                <tr>
                    <td style='background-color: #0da27d; padding: 20px; text-align: center;'>
                        <h1 style='color: #ffffff; margin: 0; letter-spacing: 1px;'>🏸 RallyHub</h1>
                    </td>
                </tr>
                
                <tr>
                    <td style='padding: 30px; color: #333333; line-height: 1.6;'>
                        {content}
                    </td>
                </tr>
                
                <tr>
                    <td style='background-color: #f9f9f9; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;'>
                        <p style='margin: 0; font-size: 12px; color: #888888;'>© 2026 RallyHub - Nền tảng kết nối người chơi cầu lông.</p>
                    </td>
                </tr>
            </table>
        </body>
        </html>";
    }
    
    public static string GenerateOtpBody(string userName, string otpCode)
    {
        string subContent = $@"
            <h2 style='color: #0da27d; font-size: 20px; margin-top: 0;'>Xác nhận tài khoản</h2>
            <p>Chào <strong>{userName}</strong>,</p>
            <p>Vui lòng sử dụng mã xác thực dưới đây để hoàn tất quá trình đăng ký:</p>
            
            <div style='text-align: center; margin: 30px 0;'>
                <span style='display: inline-block; padding: 15px 30px; font-size: 32px; font-weight: bold; color: #0da27d; background-color: #e6f6f2; border-radius: 8px; letter-spacing: 5px;'>
                    {otpCode}
                </span>
            </div>
            
            <p style='font-size: 14px; color: #777777;'>Mã này sẽ hết hạn sau <strong>5 phút</strong>. Tuyệt đối không chia sẻ mã này cho bất kỳ ai.</p>";

        // Gọi form chính bọc lại
        return GetMainLayout(subContent);
    }
    
    public static string GenerateNotificationBody(string userName, string title, string message)
    {
        string subContent = $@"
            <h2 style='color: #0da27d; font-size: 20px; margin-top: 0;'>{title}</h2>
            <p>Chào <strong>{userName}</strong>,</p>
            <p>{message}</p>
            <br>
            <p>Trân trọng,<br><strong>Đội ngũ RallyHub</strong></p>";

        return GetMainLayout(subContent);
    }
}