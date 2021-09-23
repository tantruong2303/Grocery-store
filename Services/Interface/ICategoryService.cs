using System.Collections.Generic;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface ICategoryService
    {
        public bool CreateCategoryHandler(Category category);
        public bool UpdateCategoryHandler(Category category);
        public List<Category> GetCategories();
        public Category GetCategory(string categoryId);

    }
}
