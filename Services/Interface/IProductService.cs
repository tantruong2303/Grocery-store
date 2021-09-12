using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Backend.Services.Interface
{
    public interface IProductService
    {
        public bool createProductHandler(CreateProductDTO input, ViewDataDictionary dataView);

    }
}