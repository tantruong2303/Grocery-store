using System.Collections.Generic;
using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders(string userId);
        public List<OrderItem> GetOrderDetail(string orderId);
    }
}