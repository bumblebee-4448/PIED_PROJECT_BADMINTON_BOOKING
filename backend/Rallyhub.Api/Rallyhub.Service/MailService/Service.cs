using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Rallyhub.Service.MailService;

public class Service : IService
{
    private readonly MailOptions _mailOptionses = new();

    public Service(IConfiguration configuration)
    {
        configuration.GetSection(nameof(MailOptions)).Bind(_mailOptionses);
    }
    
    public async Task SendMail(MailContent mailContent)
    {
        MimeMessage email = new();
        email.Sender = new MailboxAddress(_mailOptionses?.DisplayName, _mailOptionses!.Mail);
        email.From.Add(new MailboxAddress(_mailOptionses?.DisplayName, _mailOptionses!.Mail));
        email.To.Add(MailboxAddress.Parse(mailContent.To));
        email.Subject = mailContent.Subject;


        BodyBuilder builder = new();
        builder.HtmlBody = mailContent.Body;
        email.Body = builder.ToMessageBody();

        // dùng SmtpClient của MailKit
        using SmtpClient smtp = new();

        await smtp.ConnectAsync(_mailOptionses?.Host, _mailOptionses!.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailOptionses.Mail, _mailOptionses.Password);
        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}