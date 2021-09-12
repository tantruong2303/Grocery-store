using System.Collections.Generic;
using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface ICategoryRepository
    {
        public Category GetCategoryByCategoryName(string name);
        public Category GetCategoryByCategoryId(string categoryId);
        public List<Category> GetCategories();
        public Category GetCategory(string categoryId);
    }
}