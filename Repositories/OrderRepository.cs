using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        OurStoreContext context;
        public OrderRepository(OurStoreContext _context)
        {
            context = _context;
        }

        public async Task<Order> Get(int id)
        {
            return await context.Orders.Include(o=>o.User).Include(o=>o.OrderItems).FirstOrDefaultAsync(order => order.OrderId == id);
        }

        public async Task<Order> Post(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
