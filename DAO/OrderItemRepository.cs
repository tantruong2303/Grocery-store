using System.Linq;
using Backend.DAO.Interface;
using Backend.Utils;
using Backend.Models;

namespace Backend.DAO
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DBContext DBContext;
        public OrderItemRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public OrderItem GetOrderItemById(string orderItemId)
        {
            OrderItem orderItem = this.DBContext.OrderItem.FirstOrDefault(item => item.OrderItemId == orderItemId);
            if (orderItem != null)
            {
                this.DBContext.Entry(orderItem).Reference(item => item.Order).Load();
            }
            return orderItem;
        }
    }
}