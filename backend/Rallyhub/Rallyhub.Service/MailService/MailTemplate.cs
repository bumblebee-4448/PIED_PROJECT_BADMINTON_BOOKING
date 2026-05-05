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
    public static string RejectCourtTemplate(string email, string courtName, string reason)
    {
        return $@"
    <div style='font-family: Arial; padding: 20px; text-align: center;'>
        <h1 style='color: #d9534f;'>RallyHub</h1>
        <h2>Yêu cầu tạo sân bị từ chối</h2>
        <p>Xin chào <b>{email}</b>,</p>
        <p>Yêu cầu tạo sân <b>{courtName}</b> của bạn đã bị từ chối.</p>
        
        <p><b>Lý do:</b></p>
        <p style='color: #d9534f;'>{reason}</p>

        <p>Vui lòng kiểm tra và gửi lại yêu cầu mới.</p>
    </div>";
    }
    public static string ApproveCourtTemplate(string email, string courtName)
    {
        return $@"
    <div style='font-family: Arial; padding: 20px; text-align: center;'>
        <h1 style='color: #0da27d;'>RallyHub</h1>
        <h2>Yêu cầu tạo sân đã được phê duyệt</h2>
        <p>Xin chào <b>{email}</b>,</p>
        <p>Chúc mừng! Sân <b>{courtName}</b> của bạn đã được phê duyệt.</p>

        <p>Bạn có thể bắt đầu tạo sân con ngay bây giờ.</p>

        <div style='margin-top: 20px;'>
            <a href='#' style='background: #0da27d; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>
                Quản lý sân
            </a>
        </div>
    </div>";
    }
}