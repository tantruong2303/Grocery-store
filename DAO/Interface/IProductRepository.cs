using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IProductRepository
    {
        public Product GetProductById(string id);
        public Product GetProductByProductName(string name);
    }
}