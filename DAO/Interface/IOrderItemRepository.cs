using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IOrderItemRepository
    {
        public OrderItem GetOrderItemById(string orderItemId);
    }
}