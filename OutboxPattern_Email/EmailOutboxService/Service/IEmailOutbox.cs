using OutboxPattern_Email.Models;

namespace OutboxPattern_Email.EmailOutboxService.Service
{
    public interface IEmailOutbox
    {
        Task<EmailOutbox> Add(EmailOutbox emailOutbox);
        Task<EmailOutbox> Update(EmailOutbox emailOutbox);
        IEnumerable<EmailOutbox> GetAll();
    }
}
