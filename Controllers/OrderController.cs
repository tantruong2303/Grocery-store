using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Backend.Pipe;
using Backend.Models;
using Backend.Utils.Locale;
using Backend.Controllers.DTO;

namespace Backend.Controllers
{
    [Route("order")]

    public class OrderController : Controller
    {
        private readonly IOrderService OrderService;
        private const string CartSession = "CartSession";
        private readonly ICartService CartService;
        public OrderController(IOrderService orderService, ICartService cartService)
        {
            this.OrderService = orderService;
            this.CartService = cartService;
        }

        [HttpGet("")]
        [RoleGuardAttribute(new UserRole[] { UserRole.CUSTOMER })]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Order()
        {
            var user = (User)this.ViewData["user"];
            var orders = this.OrderService.GetOrders(user.UserId);
            this.ViewData["orders"] = orders;
            return View(Routers.Order.Page);
        }

        [HttpGet("manager")]
        [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult GetAllOrders(string startDate, string endDate, string search)
        {
            var orders = this.OrderService.GetAllOrders();
            this.ViewData["orders"] = orders;
            return View(Routers.Manager.Page);
        }

        [HttpGet("search")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult SearchOrders(string startDate, string endDate, string search)
        {
            var orders = this.OrderService.SearchOrders(startDate, endDate, search);
            this.ViewData["orders"] = orders;
            return View(Routers.SearchOrders.Page);
        }

        [HttpPost("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult CreateOrder(PaymentMethod paymentMethod)
        {
            string cart = this.HttpContext.Session.GetString(CartSession);
            if (cart == null || cart == "")
            {
                ServerResponse.SetFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_INVALID_FILE, this.ViewData);
                return Redirect(Routers.Home.Link);
            }

            var input = new CreateOrderDTO()
            {
                PaymentMethod = paymentMethod,
            };

            var isValid = this.OrderService.CreateOrderHandler(input, this.ViewData, cart);
            if (!isValid)
            {
                return Redirect(Routers.Home.Link);
            }
            return Redirect(Routers.Home.Link);
        }
    }
}