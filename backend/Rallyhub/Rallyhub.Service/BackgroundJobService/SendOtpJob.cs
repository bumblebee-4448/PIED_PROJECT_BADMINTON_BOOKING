using Quartz;
using Rallyhub.Service.MailService;

namespace Rallyhub.Service.BackgroundJobService;

public class SendOtpJob : IJob
{
    private readonly IService _mailService;

    public SendOtpJob(IService mailService)
    {
        _mailService = mailService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        string email = context.MergedJobDataMap.GetString("Email")!;
        string otpCode = context.MergedJobDataMap.GetString("OtpCode")!;

        // 2. Tạo form HTML
        string htmlBody = MailTemplate.GenerateOtpTemplate(email, otpCode);

        // 3. Đưa cho MailService đi gửi
        await _mailService.SendMail(new MailContent()
        {
            To = email,
            Subject = "Mã xác thực tài khoản RallyHub",
            Body = htmlBody
        });
    }
}