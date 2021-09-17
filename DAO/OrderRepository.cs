using System.Collections.Generic;
using Backend.DAO.Interface;
using Backend.Models;
using Backend.Utils;
using System.Linq;
using System;

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

        public List<Order> GetAllOrders()
        {
            List<Order> orders = this.DBContext.Order.ToList();
            return orders;
        }

        public List<Order> SearchOrders(string startDate, string endDate, string search)
        {
            List<string> stringDate = new List<string>();
            stringDate = startDate.Split('-').ToList();
            startDate = stringDate[1] + "/" + stringDate[2] + "/" + stringDate[0];
            stringDate = endDate.Split('-').ToList();
            endDate = stringDate[1] + "/" + stringDate[2] + "/" + stringDate[0];
            DateTime sDate = Convert.ToDateTime(startDate);
            DateTime eDate = Convert.ToDateTime(endDate);
            List<Order> orders = this.DBContext.Order.Where(x => x.Customer.Name.Contains(search) || x.Customer.Phone.Contains(search) || x.Customer.Email.Contains(search)).ToList();

            for (int i = orders.Count - 1; i >= 0; i--)
            {
                DateTime date = Convert.ToDateTime(orders[i].CreateDate);
                if (DateTime.Compare(date, eDate) > 0 || DateTime.Compare(date, sDate) < 0)
                {
                    orders.RemoveAt(i);
                }
            }
            return orders;
        }

    }
}