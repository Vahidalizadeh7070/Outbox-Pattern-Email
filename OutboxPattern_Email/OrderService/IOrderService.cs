using OutboxPattern_Email.Models;

namespace OutboxPattern_Email.OrderService
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Order GetOrder(string id);
    }
}
