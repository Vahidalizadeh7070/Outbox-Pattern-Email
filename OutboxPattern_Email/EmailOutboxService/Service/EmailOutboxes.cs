using Microsoft.EntityFrameworkCore;
using OutboxPattern_Email.Models;

namespace OutboxPattern_Email.EmailOutboxService.Service
{
    public class EmailOutboxes : IEmailOutbox
    {
        private readonly AppDbContext _appDbContext;

        public EmailOutboxes(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<EmailOutbox> Add(EmailOutbox emailOutbox)
        {
            if(emailOutbox is not null)
            {
                await _appDbContext.EmailOutbox.AddAsync(emailOutbox);
                await _appDbContext.SaveChangesAsync(); 
            }
            return emailOutbox;
        }

        public IEnumerable<EmailOutbox> GetAll()
        {
            return _appDbContext.EmailOutbox.Include(o=>o.Order).OrderByDescending(o=>o.CreatedDate).Where(o=>o.Success==false).ToList();
        }

        public async Task<EmailOutbox> Update(EmailOutbox emailOutbox)
        {
            var model = await _appDbContext.EmailOutbox.FirstOrDefaultAsync(o=>o.Id ==emailOutbox.Id);
            if(model is not null)
            {
                model.Success = true;
                await _appDbContext.SaveChangesAsync();
            }
            return emailOutbox;
        }
    }
}
