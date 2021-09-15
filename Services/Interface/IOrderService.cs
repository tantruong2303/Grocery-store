using System.Collections.Generic;
using Backend.Models;
namespace Backend.Services.Interface
{
    public interface IOrderService
    {
        public List<Order> GetOrders(string userId);
        public List<OrderItem> GetOrderDetail(string orderId);
        public List<Order> GetAllOrders();
        public List<Order> SearchOrders(string startDate, string endDate, string search);
    }
}