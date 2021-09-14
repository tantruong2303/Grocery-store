using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Services.Interface;

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
        public IActionResult Index()
        {
            var (products, count) = this.ProductService.GetProducts();
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;
            return View(Routers.Home.Page);
        }
    }
}
