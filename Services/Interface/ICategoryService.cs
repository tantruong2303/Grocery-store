using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace Backend.Services.Interface
{
    public interface ICategoryService
    {
        public bool CreateCategoryHandler(CreateCategoryDTO input, ViewDataDictionary dataView);
        public bool UpdateCategoryHandler(UpdateCategoryDTO input, ViewDataDictionary dataView);
        public bool DeleteCategoryHandler(DeleteCategoryDTO input, ViewDataDictionary dataView);
    }
}
