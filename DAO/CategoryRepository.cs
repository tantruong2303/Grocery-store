using System.Collections.Generic;
using Backend.DAO.Interface;
using Backend.Models;
using Backend.Utils;
using System.Linq;

namespace Backend.DAO
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBContext DBContext;

        public CategoryRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = this.DBContext.Category.ToList();
            return categories;
        }
        public Category GetCategory(string categoryId)
        {
            Category category = this.DBContext.Category.Find(categoryId);
            return category;
        }

        public Category GetCategoryByCategoryName(string name)
        {
            Category category = this.DBContext.Category.FirstOrDefault(item => item.Name == name);
            return category;
        }
        public Category GetCategoryByCategoryId(string categoryId)
        {
            Category category = this.DBContext.Category.FirstOrDefault(item => item.CategoryId == categoryId);
            return category;
        }
    }
}