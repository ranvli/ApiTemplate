using ApiTest.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ApiTest.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private const string DataFilePath = "data.json";
        private Data data;

        public OrderRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                var jsonData = File.ReadAllText(DataFilePath);
                data = JsonSerializer.Deserialize<Data>(jsonData) ?? new Data();
            }
            else
            {
                data = new Data();
            }
        }

        public IEnumerable<Order> GetAllOrders() => data.Orders;

        public Order? GetOrderById(int id) => data.Orders.FirstOrDefault(o => o.Id == id);

        public void AddOrder(Order order)
        {
            data.Orders.Add(order);
            SaveData();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = GetOrderById(order.Id);
            if (existingOrder != null)
            {
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.Total = order.Total;
                existingOrder.Status = order.Status;
                existingOrder.ShippingAddress = order.ShippingAddress;
                SaveData();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order != null)
            {
                data.Orders.Remove(order);
                SaveData();
            }
        }

        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(DataFilePath, jsonData);
        }
    }
}

