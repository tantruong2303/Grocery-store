using backend.Models;

namespace backend.DAO.Interface
{
    public interface ICategoryRepository
    {
        public Category getCategoryByCategoryName(string name);
        public Category getCategoryByCategoryId(string categoryId);
    }
}