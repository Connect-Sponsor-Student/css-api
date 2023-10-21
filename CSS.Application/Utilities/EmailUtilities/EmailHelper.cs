using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CSS.Application.Utilities.EmailUtilities;
public class EmailHelper : IEmailHelper
{
    
    private readonly EmailConfig emailConfig;
    public EmailHelper(IOptions<EmailConfig> config)
    {
       emailConfig = config.Value;
    }

    public async Task<bool> SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            var _email = emailConfig.Email;
            var _epass = emailConfig.Password;
            var _dispName = emailConfig.DisplayName;
            MailMessage myMessage = new MailMessage();
            myMessage.IsBodyHtml = true;
            myMessage.To.Add(email);
            myMessage.From = new MailAddress(_email!, _dispName);
            myMessage.Subject = subject;
            myMessage.Body = message;
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_email, _epass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                await smtp.SendMailAsync(myMessage);
            }
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
            throw;
        }
    }

   
}