namespace Rallyhub.Service.MailService;

public static class MailTemplate
{
    public static string GenerateOtpRegisterTemplate(string email, string otpCode)
    {
        return $@"
        <span style=""display:none; visibility:hidden; mso-hide:all; font-size:1px; line-height:1px; max-height:0px; max-width:0px; opacity:0; overflow:hidden;"">
            Mã xác thực đăng kí tài khoản
            &nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;
        </span>

        <div style=""background-color: #f4f7f6; padding: 40px 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.05);"">
                
                <!-- Header -->
                <div style=""background-color: #0da27d; padding: 30px; text-align: center;"">
                    <h1 style=""color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 2px;"">RallyHub</h1>
                </div>

                <!-- Body -->
                <div style=""padding: 40px 30px; text-align: center;"">
                    <h2 style=""color: #333333; margin-top: 0; font-size: 24px;"">Xác thực tài khoản</h2>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 30px;"">
                        Xin chào <strong style=""color: #333333;"">{email}</strong>,<br>
                        Cảm ơn bạn đã tham gia hệ thống. Dưới đây là mã xác thực (OTP) của bạn để hoàn tất quá trình đăng ký:
                    </p>

                    <div style='margin: 35px 0;'>
                        <style>
                            @keyframes floatingLava {{
                                0% {{
                                    background-position: 0% 0%;
                                    filter: hue-rotate(0deg);
                                    transform: translateY(0px) rotate(0deg);
                                    box-shadow: 0 0 20px rgba(255, 61, 0, 0.8), 0 0 40px rgba(255, 234, 0, 0.4);
                                }}
                                33% {{
                                    background-position: 100% 50%;
                                    filter: hue-rotate(120deg);
                                    transform: translateY(-8px) rotate(2deg);
                                    box-shadow: 0 0 30px rgba(255, 61, 0, 0.9), 0 0 50px rgba(255, 234, 0, 0.6);
                                }}
                                66% {{
                                    background-position: 0% 100%;
                                    filter: hue-rotate(240deg);
                                    transform: translateY(6px) rotate(-2deg);
                                    box-shadow: 0 0 25px rgba(255, 61, 0, 0.8), 0 0 45px rgba(255, 234, 0, 0.5);
                                }}
                                100% {{
                                    background-position: 0% 0%;
                                    filter: hue-rotate(360deg);
                                    transform: translateY(0px) rotate(0deg);
                                    box-shadow: 0 0 20px rgba(255, 61, 0, 0.8), 0 0 40px rgba(255, 234, 0, 0.4);
                                }}
                            }}
                        </style>
                        <div style=""display: inline-block; padding: 15px 35px; background: linear-gradient(135deg, #FF3D00, #FFEA00, #FF3D00); background-size: 300% 300%; border-radius: 16px; color: #ffffff; font-size: 32px; font-weight: 900; letter-spacing: 8px; text-shadow: 0 2px 5px rgba(0,0,0,0.5); animation: floatingLava 8s ease-in-out infinite; box-shadow: 0 0 20px rgba(255, 61, 0, 0.8); border: 2px solid rgba(255,255,255,0.6); font-family: 'Courier New', Courier, monospace;"">
                            {otpCode}
                        </div>
                    </div>

                    <p style=""color: #888888; font-size: 14px; margin-top: 30px; line-height: 1.5;"">
                        Mã này sẽ hết hạn sau <strong style=""color: #e74c3c;"">5 phút</strong>.<br>
                        Vui lòng không chia sẻ mã này cho bất kỳ ai để bảo vệ tài khoản của bạn.
                    </p>
                </div>

                <!-- Footer -->
                <div style=""background-color: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;"">
                    <p style=""color: #aaaaaa; font-size: 12px; margin: 0; line-height: 1.5;"">
                        &copy; RallyHub. Tất cả các quyền được bảo lưu.<br>
                        Đây là email tự động, vui lòng không trả lời email này.
                    </p>
                </div>
            </div>
        </div>";
    }
    
    public static string GeneratePasswordResetTemplate(string email, string otpcode)
    {
        return $@"
        <span style=""display:none; visibility:hidden; mso-hide:all; font-size:1px; line-height:1px; max-height:0px; max-width:0px; opacity:0; overflow:hidden;"">
            Mã xác thực tài khoản quên mật khẩu
            &nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;
        </span>

        <div style=""background-color: #f4f7f6; padding: 40px 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.05);"">
                <div style=""background-color: #0da27d; padding: 30px; text-align: center;"">
                    <h1 style=""color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 2px;"">RallyHub</h1>
                </div>
                <div style=""padding: 40px 30px; text-align: center;"">
                    <h2 style=""color: #333333; margin-top: 0; font-size: 24px;"">Yêu cầu đặt lại mật khẩu</h2>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 30px;"">
                        Xin chào <strong style=""color: #333333;"">{email}</strong>,<br>
                        Chúng tôi nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn. Mã xác thực của bạn là:
                    </p>
                    <div style='margin: 35px 0;'>
                        <style>
                            @keyframes floatingLava {{
                                0% {{
                                    background-position: 0% 0%;
                                    filter: hue-rotate(0deg);
                                    transform: translateY(0px) rotate(0deg);
                                    box-shadow: 0 0 20px rgba(255, 61, 0, 0.8), 0 0 40px rgba(255, 234, 0, 0.4);
                                }}
                                33% {{
                                    background-position: 100% 50%;
                                    filter: hue-rotate(120deg);
                                    transform: translateY(-8px) rotate(2deg);
                                    box-shadow: 0 0 30px rgba(255, 61, 0, 0.9), 0 0 50px rgba(255, 234, 0, 0.6);
                                }}
                                66% {{
                                    background-position: 0% 100%;
                                    filter: hue-rotate(240deg);
                                    transform: translateY(6px) rotate(-2deg);
                                    box-shadow: 0 0 25px rgba(255, 61, 0, 0.8), 0 0 45px rgba(255, 234, 0, 0.5);
                                }}
                                100% {{
                                    background-position: 0% 0%;
                                    filter: hue-rotate(360deg);
                                    transform: translateY(0px) rotate(0deg);
                                    box-shadow: 0 0 20px rgba(255, 61, 0, 0.8), 0 0 40px rgba(255, 234, 0, 0.4);
                                }}
                            }}
                        </style>
                        <div style=""display: inline-block; padding: 15px 35px; background: linear-gradient(135deg, #FF3D00, #FFEA00, #FF3D00); background-size: 300% 300%; border-radius: 16px; color: #ffffff; font-size: 32px; font-weight: 900; letter-spacing: 8px; text-shadow: 0 2px 5px rgba(0,0,0,0.5); animation: floatingLava 8s ease-in-out infinite; box-shadow: 0 0 20px rgba(255, 61, 0, 0.8); border: 2px solid rgba(255,255,255,0.6); font-family: 'Courier New', Courier, monospace;"">
                            {otpcode}
                        </div>
                    </div>
                    <p style=""color: #888888; font-size: 14px; margin-top: 30px; line-height: 1.5;"">
                        Mã này sẽ hết hạn sau <strong style=""color: #e74c3c;"">5 phút</strong>.<br>
                        Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này.
                    </p>
                </div>
                <div style=""background-color: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;"">
                    <p style=""color: #aaaaaa; font-size: 12px; margin: 0; line-height: 1.5;"">
                        &copy; RallyHub. Tất cả các quyền được bảo lưu.<br>
                        Đây là email tự động, vui lòng không trả lời email này.
                    </p>
                </div>
            </div>
        </div>";
    }
    
    public static string GenerateApprovalTemplate(string email, string bodyMail)
    {
        return $@"
        <span style=""display:none; visibility:hidden; mso-hide:all; font-size:1px; line-height:1px; max-height:0px; max-width:0px; opacity:0; overflow:hidden;"">
            Phản hồi về yêu cầu của bạn
            &nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;
        </span><div style=""display: none; max-height: 0px; overflow: hidden;"">&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;</div>

        <div style=""background-color: #f4f7f6; padding: 40px 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.05);"">
                <div style=""background-color: #0da27d; padding: 30px; text-align: center;"">
                    <h1 style=""color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 2px;"">RallyHub</h1>
                </div>
                <div style=""padding: 40px 30px; text-align: center;"">
                    <h2 style=""color: #0da27d; margin-top: 0; font-size: 24px;"">Chúc mừng bạn!</h2>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">
                        Xin chào đối tác <strong style=""color: #333333;"">{email}</strong>,
                    </p>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 30px;"">{bodyMail}</p>
                    <a href='https://pied-project-badminton-booking-z3oj.onrender.com' style='background-color: #0da27d; color: white; padding: 12px 24px; text-decoration: none; border-radius: 8px; display: inline-block; font-weight: bold; font-size: 16px; margin-bottom: 20px;'>Truy cập hệ thống ngay</a>
                </div>
                <div style=""background-color: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;"">
                    <p style=""color: #aaaaaa; font-size: 12px; margin: 0; line-height: 1.5;"">
                        Cảm ơn bạn đã tin tưởng và đồng hành cùng RallyHub.<br>
                        &copy; RallyHub. Tất cả các quyền được bảo lưu.
                    </p>
                </div>
            </div>
        </div>";
    }
    
    public static string GenerateRejectionTemplate(string email, string bodyMail, string? reason)
    {
        return $@"
        <span style=""display:none; visibility:hidden; mso-hide:all; font-size:1px; line-height:1px; max-height:0px; max-width:0px; opacity:0; overflow:hidden;"">
            Phản hồi về yêu cầu của bạn
            &nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;
        </span>

        <div style=""background-color: #f4f7f6; padding: 40px 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.05);"">
                <div style=""background-color: #e74c3c; padding: 30px; text-align: center;"">
                    <h1 style=""color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 2px;"">RallyHub</h1>
                </div>
                <div style=""padding: 40px 30px; text-align: center;"">
                    <h2 style=""color: #e74c3c; margin-top: 0; font-size: 24px;"">Thông báo cập nhật hồ sơ</h2>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">
                        Xin chào <strong style=""color: #333333;"">{email}</strong>,
                    </p>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">{bodyMail}</p>
                    <div style='background: #fdf2f0; border-left: 4px solid #e74c3c; padding: 15px 20px; border-radius: 4px; margin: 25px 0; text-align: left;'>
                        <strong style='color: #e74c3c; font-size: 14px; display: block; margin-bottom: 5px;'>LÝ DO:</strong>
                        <span style='color: #e74c3c; font-size: 15px;'>{reason}</span>
                    </div>
                    <p style=""color: #666666; font-size: 15px; line-height: 1.6;"">
                        Bạn vui lòng kiểm tra lại thông tin, khắc phục vấn đề nêu trên và gửi lại yêu cầu phê duyệt mới trên ứng dụng nhé.
                    </p>
                </div>
                <div style=""background-color: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;"">
                    <p style=""color: #aaaaaa; font-size: 12px; margin: 0; line-height: 1.5;"">
                        Nếu cần hỗ trợ, hãy liên hệ với bộ phận chăm sóc khách hàng của chúng tôi.<br>
                        &copy; RallyHub. Tất cả các quyền được bảo lưu.
                    </p>
                </div>
            </div>
        </div>";
    }
    
    public static string RejectCourtTemplate(string email, string courtName, string reason)
    {
        return $@"
        <div style=""background-color: #f4f7f6; padding: 40px 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.05);"">
                <div style=""background-color: #d9534f; padding: 30px; text-align: center;"">
                    <h1 style=""color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 2px;"">RallyHub</h1>
                </div>
                <div style=""padding: 40px 30px; text-align: center;"">
                    <h2 style=""color: #d9534f; margin-top: 0; font-size: 24px;"">Yêu cầu tạo sân bị từ chối</h2>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">
                        Xin chào <strong style=""color: #333333;"">{email}</strong>,
                    </p>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">
                        Yêu cầu tạo sân <strong style=""color: #333333;"">{courtName}</strong> của bạn đã bị từ chối.
                    </p>
                    <div style='background: #fdf2f0; border-left: 4px solid #d9534f; padding: 15px 20px; border-radius: 4px; margin: 25px 0; text-align: left;'>
                        <strong style='color: #d9534f; font-size: 14px; display: block; margin-bottom: 5px;'>LÝ DO:</strong>
                        <span style='color: #d9534f; font-size: 15px;'>{reason}</span>
                    </div>
                    <p style=""color: #666666; font-size: 15px; line-height: 1.6;"">
                        Vui lòng kiểm tra và gửi lại yêu cầu mới.
                    </p>
                </div>
                <div style=""background-color: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;"">
                    <p style=""color: #aaaaaa; font-size: 12px; margin: 0; line-height: 1.5;"">
                        &copy; RallyHub. Tất cả các quyền được bảo lưu.
                    </p>
                </div>
            </div>
        </div>";
    }
    
    
    public static string ApproveCourtTemplate(string email, string courtName)
    {
        return $@"
        <div style=""background-color: #f4f7f6; padding: 40px 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;"">
            <div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.05);"">
                <div style=""background-color: #0da27d; padding: 30px; text-align: center;"">
                    <h1 style=""color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 2px;"">RallyHub</h1>
                </div>
                <div style=""padding: 40px 30px; text-align: center;"">
                    <h2 style=""color: #0da27d; margin-top: 0; font-size: 24px;"">Yêu cầu tạo sân đã được phê duyệt</h2>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">
                        Xin chào <strong style=""color: #333333;"">{email}</strong>,
                    </p>
                    <p style=""color: #666666; font-size: 16px; line-height: 1.6; margin-bottom: 20px;"">
                        Chúc mừng! Sân <strong style=""color: #333333;"">{courtName}</strong> của bạn đã được phê duyệt.
                    </p>
                    <p style=""color: #666666; font-size: 15px; line-height: 1.6; margin-bottom: 30px;"">
                        Bạn có thể bắt đầu tạo sân con ngay bây giờ.
                    </p>
                    <a href='#' style='background-color: #0da27d; color: white; padding: 12px 24px; text-decoration: none; border-radius: 8px; display: inline-block; font-weight: bold; font-size: 16px; margin-bottom: 10px;'>
                        Quản lý sân
                    </a>
                </div>
                <div style=""background-color: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;"">
                    <p style=""color: #aaaaaa; font-size: 12px; margin: 0; line-height: 1.5;"">
                        &copy; RallyHub. Tất cả các quyền được bảo lưu.
                    </p>
                </div>
            </div>
        </div>";
    }
}