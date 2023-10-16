 using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var smtpClient = new SmtpClient
        {
            Host = "smtp.google.com", // замените на ваш SMTP-сервер
            Port = 465, // порт вашего SMTP-сервера
            EnableSsl = true,
            Credentials = new NetworkCredential("rbnrbn752@gmail.com", "123456") // учетные данные вашего аккаунта электронной почты
        };
        using (var mailMessage = new MailMessage("from@example.com", email))
        {
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}