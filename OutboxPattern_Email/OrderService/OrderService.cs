using Microsoft.EntityFrameworkCore;
using OutboxPattern_Email.Models;

namespace OutboxPattern_Email.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _appDbContext;

        public OrderService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            if(order is not null)
            {
                await _appDbContext.Orders.AddAsync(order);
                await _appDbContext.SaveChangesAsync();
            }
            return order;
        }

        public Order GetOrder(string id)
        {
            return _appDbContext.Orders.FirstOrDefault(o=>o.Id == id);
        }
    }
}
