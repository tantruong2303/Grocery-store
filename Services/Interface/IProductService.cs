using backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace backend.Services.Interface
{
    public interface IProductService
    {
        public bool createProductHandler(CreateProductDTO input, ViewDataDictionary dataView);

    }
}