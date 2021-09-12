using System.Collections.Generic;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface ICategoryService
    {
        public bool CreateCategoryHandler(CreateCategoryDTO input, ViewDataDictionary dataView);
        public bool UpdateCategoryHandler(UpdateCategoryDTO input, ViewDataDictionary dataView);
        public bool DeleteCategoryHandler(DeleteCategoryDTO input, ViewDataDictionary dataView);
        public List<Category> GetCategories();
        public Category GetCategory(string categoryId);
    }
}
