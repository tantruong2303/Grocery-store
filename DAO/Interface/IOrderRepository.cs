using System.Collections.Generic;
using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IOrderRepository
    {
        public (List<Order>, int) GetOrders(string userId, int pageIndex, int pageSize);


        public (List<OrderItem>, int) GetOrderDetail(string orderId, int pageIndex, int pageSize);
        public List<Order> GetAllOrders();
        public (List<Order>, int) SearchOrders(string startDate, string endDate, string search, int pageIndex, int pageSize);


        public bool CreateOrderHandler(Order order);
        public bool CreateOrderItemHandler(OrderItem orderItem);

    }
}