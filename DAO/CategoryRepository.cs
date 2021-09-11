using backend.DAO.Interface;
using backend.Models;
using backend.Utils;
using System.Linq;

namespace backend.DAO
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBContext dBContext;

        public CategoryRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Category getCategoryByCategoryName(string name)
        {
            Category category = this.dBContext.category.FirstOrDefault(item => item.name == name);
            return category;
        }
        public Category getCategoryByCategoryId(string categoryId)
        {
            Category category = this.dBContext.category.FirstOrDefault(item => item.categoryId == categoryId);
            return category;
        }
    }
}