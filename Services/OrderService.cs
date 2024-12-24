using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;

        public OrderService(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }

        public Task<Order> Get(int id)
        {
            return orderRepository.Get(id);
        }

        public async Task<Order> Post(Order order)
        {
            return await orderRepository.Post(order);
        }
    }
}
