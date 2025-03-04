using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Extensions.Logging;

namespace Services
{//
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        IProductRepository productRepository;
        ILogger logger;

        public OrderService(IOrderRepository _orderRepository, IProductRepository _productRepository,ILogger<OrderService> _logger)
        {
            orderRepository = _orderRepository;
            productRepository = _productRepository;
            logger = _logger;
        }

        public Task<Order> Get(int id)
        {
            return orderRepository.Get(id);
        }

        public async Task<Order> Post(Order order)
        {
            double orderSum = await GetSumOrder(order);
            if(orderSum != order.OrderSum)
            {
                logger.LogCritical("The order sumarize doesn't equal to the original prices");
                order.OrderSum = orderSum;
            }
            return await orderRepository.Post(order);
        }

        private async Task<double> GetSumOrder(Order order)
        {
            double sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product p = await productRepository.Get(item.ProductId);
                sum += p.Price;
            }
            return sum;
        }
    }
}
