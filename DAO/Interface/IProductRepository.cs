using backend.Models;

namespace backend.DAO.Interface
{
    public interface IProductRepository
    {
        public Product getProductById(string id);
        public Product getProductByProductName(string name);
    }
}