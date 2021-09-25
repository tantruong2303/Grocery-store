using System.Collections.Generic;
using Backend.Controllers.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Backend.DAO.Interface
{
    public interface ICategoryRepository
    {
        public Category GetCategoryByCategoryName(string name);
        public Category GetCategoryByCategoryId(string categoryId);
        public List<Category> GetCategories();
        public Category GetCategory(string categoryId);
        public bool CreateCategoryHandler(Category category);
        public bool UpdateCategoryHandler(Category category);
    }
}