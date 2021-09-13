using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IProductRepository
    {
        public Product GetProductById(string productId);
        public Product GetProductByProductName(string name);
    }
}