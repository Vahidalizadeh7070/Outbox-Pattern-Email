namespace OutboxPattern_Email.EmailService
{
    public interface IMailService
    {
        bool Send(string sender, string subject, string body, bool isBodyHTML);
    }
}
