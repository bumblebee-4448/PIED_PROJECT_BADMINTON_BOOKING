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
        string actionType = context.MergedJobDataMap.GetString("ActionType")!;

        string subject = "";
        string htmlBody = "";
        
        switch (actionType)
        {
            case "Register":
                subject = "Người tình trong mộng Rallyhub";
                htmlBody = MailTemplate.GenerateOtpRegisterTemplate(email, otpCode);
                break;
            
            case "ForgotPassword":
                subject = "Người tình trong mộng Rallyhub";
                htmlBody = MailTemplate.GeneratePasswordResetTemplate(email, otpCode);
                break;
        }

        await _mailService.SendMail(new MailContent()
        {
            To = email,
            Subject = subject,
            Body = htmlBody
        });
    }
}