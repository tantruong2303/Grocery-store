using System.Collections.Generic;
using Backend.DAO.Interface;
using Backend.Models;
using Backend.Utils;
using System.Linq;

namespace Backend.DAO
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DBContext DBContext;
        public OrderRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public List<Order> GetOrders(string userId)
        {

            List<Order> orders = this.DBContext.Order.Where(o => o.CustomerId == userId).ToList();
            return orders;
        }

        public List<OrderItem> GetOrderDetail(string orderId)
        {
            List<OrderItem> orderItems = this.DBContext.OrderItem.Where(x => x.OrderId == orderId).ToList();
            return orderItems;
        }
    }
}