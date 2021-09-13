using System.Collections.Generic;
using Backend.Models;
namespace Backend.Services.Interface
{
    public interface IOrderService
    {
        public List<Order> GetOrders(string userId);
        public List<OrderItem> GetOrderDetail(string orderId);
    }
}