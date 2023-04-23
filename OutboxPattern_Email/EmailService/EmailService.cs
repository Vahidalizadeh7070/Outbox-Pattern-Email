using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace OutboxPattern_Email.EmailService
{
    public class EmailService : IMailService
    {
        private readonly EmailSettings _emailSettings;

        // Constructor
        public EmailService(IOptions<EmailSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value;
        }

        // Send email
        public bool Send(string sender, string subject, string body, bool isBodyHTML)
        {
            try
            {
                // Create an object based on the MailMessage class
                MailMessage mailMessage = new MailMessage();

                // Assign properties that are required for sending an email
                mailMessage.From = new MailAddress(_emailSettings.Email);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isBodyHTML;
                // Send email to ...
                mailMessage.To.Add(new MailAddress(sender));

                // Generate a SmtpClient object
                SmtpClient smtp = new SmtpClient();

                // smtp.Host = smtp.gmail.com;
                smtp.Host = "mail.vahidalizadeh7070.ir";

                // If using gmail, set it true
                smtp.EnableSsl = false;

                // Set username and password of our email 
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = mailMessage.From.Address;
                networkCredential.Password = _emailSettings.Password;

                // If using gmail, set it true
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;

                // If using google set it 587
                smtp.Port = 587;

                // Send 
                smtp.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
