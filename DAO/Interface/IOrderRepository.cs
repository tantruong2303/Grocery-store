using System.Collections.Generic;
using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders(string userId);
        public (List<OrderItem>, int) GetOrderDetail(string orderId, int pageIndex, int pageSize);
        public List<Order> GetAllOrders();
        public List<Order> SearchOrders(string startDate, string endDate, string search);
        public bool CreateOrderHandler(Order order);
        public bool CreateOrderItemHandler(OrderItem orderItem);

    }
}