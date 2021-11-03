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

        public (List<OrderItem>, int) GetOrderDetail(string orderId, int pageIndex, int pageSize)
        {
            List<OrderItem> orderItems = this.DBContext.OrderItem.Where(x => x.OrderId == orderId).ToList();
            foreach (var orderItem in orderItems)
            {
                this.DBContext.Entry(orderItem).Reference(item => item.Product).Load();
                this.DBContext.Entry(orderItem.Product).Reference(item => item.Category).Load();
            }
            var pagelist = (List<OrderItem>)orderItems.Take((pageIndex + 1) * pageSize).Skip(pageIndex * pageSize).ToList();
            return (pagelist, orderItems.Count);
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = this.DBContext.Order.ToList();
            return orders;
        }

        public List<Order> SearchOrders(string startDate, string endDate, string search)
        {
            if (search == null)
            {
                search = "";
            }
            search = search.ToLower();
            List<string> stringDate = new List<string>();
            stringDate = startDate.Split('-').ToList();
            startDate = stringDate[1] + "/" + stringDate[2] + "/" + stringDate[0];
            stringDate = endDate.Split('-').ToList();
            endDate = stringDate[1] + "/" + stringDate[2] + "/" + stringDate[0];
            DateTime sDate = Convert.ToDateTime(startDate);
            DateTime eDate = Convert.ToDateTime(endDate);
            List<Order> orders = this.DBContext.Order.ToList();
            foreach (var order in orders)
            {
                this.DBContext.Entry(order).Reference(item => item.Customer).Load();
            }

            for (int i = orders.Count - 1; i >= 0; i--)
            {
                DateTime date = Convert.ToDateTime(orders[i].CreateDate);
                if (DateTime.Compare(date, eDate) > 0 || DateTime.Compare(date, sDate) < 0 || (!orders[i].Customer.Name.ToLower().Contains(search) && !orders[i].Customer.Email.Contains(search) && !orders[i].Customer.Phone.Contains(search)))
                {
                    orders.RemoveAt(i);
                }
            }
            return orders;
        }


        public bool CreateOrderHandler(Order order)
        {
            this.DBContext.Order.Add(order);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool CreateOrderItemHandler(OrderItem orderItem)
        {
            this.DBContext.OrderItem.Add(orderItem);
            this.DBContext.SaveChanges();
            return true;
        }

    }
}