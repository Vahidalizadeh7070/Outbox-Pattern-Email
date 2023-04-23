using System.ComponentModel.DataAnnotations;

namespace OutboxPattern_Email.Models
{
    public class EmailOutbox
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Success { get; set; }
    }
}
