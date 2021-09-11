using backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using backend.Models;
namespace backend.Services.Interface
{
    public interface ICategoryService
    {
        public bool createCategoryHandler(CreateCategoryDTO input, ViewDataDictionary dataView);
        public bool updateCategoryHandler(UpdateCategoryDTO input, ViewDataDictionary dataView);
        public bool deleteCategoryHandler(DeleteCategoryDTO input, ViewDataDictionary dataView);
    }
}
