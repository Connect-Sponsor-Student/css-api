namespace CSS.Application.Utilities.EmailUtilities;
public interface IEmailHelper
{
    Task<bool> SendEmailAsync(string email, string subject, string message);
}