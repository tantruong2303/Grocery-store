using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Services.Interface;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using System;

namespace Backend.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        private readonly IProductService ProductService;

        public HomeController(IProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Index(double min, double max)
        {
            var (products, count) = this.ProductService.GetProducts(0, double.MaxValue);
            var input = new SearchProductDTO()
            {
                Min = min,
                Max = max
            };

            ValidationResult result = new SearchProductDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, this.ViewData);
                this.ViewData["products"] = products;
                this.ViewData["count"] = count;
                return View(Routers.Home.Page);
            }
            (products, count) = this.ProductService.GetProducts(min, max);
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;
            return View(Routers.Home.Page);
        }
    }
}
