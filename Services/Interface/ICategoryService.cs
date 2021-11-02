using System.Collections.Generic;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Backend.Services.Interface
{
    public interface ICategoryService
    {
        public bool CreateCategoryHandler(Category category);
        public bool UpdateCategoryHandler(Category category);
        public List<Category> GetCategories();
        public Category GetCategory(string categoryId);
        public List<SelectListItem> GetCategoryDropListRender(CategoryStatus categoryStatus);
        public (List<Category>, int) GetAllCategoriesWithStatus(int pageIndex, int pageSize, string searchName, CategoryStatus searchStatus);
        public List<SelectListItem> GetCategoryStatusDropListRender();

    }
}
