using ApiTest.Entities;
using ApiTest.Repositories;
using System.Collections.Generic;

namespace ApiTest.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAllOrders() => _orderRepository.GetAllOrders();

        public Order? GetOrderById(int id) => _orderRepository.GetOrderById(id);

        public void AddOrder(Order order) => _orderRepository.AddOrder(order);

        public void UpdateOrder(Order order) => _orderRepository.UpdateOrder(order);

        public void DeleteOrder(int id) => _orderRepository.DeleteOrder(id);
    }
}
