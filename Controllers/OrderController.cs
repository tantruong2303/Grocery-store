using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Backend.Pipe;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("order")]
    [ServiceFilter(typeof(AuthGuard))]
    public class OrderController : Controller
    {
        private readonly IOrderService OrderService;
        public OrderController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }

        [HttpGet("")]
        public IActionResult Order()
        {
            var user = (User)this.ViewData["user"];
            var orders = this.OrderService.GetOrders(user.UserId);
            this.ViewData["orders"] = orders;
            return View(Routers.Order.Page);
        }

        [HttpGet("manager")]
        public IActionResult GetAllOrders(string startDate, string endDate, string search)
        {
            var orders = this.OrderService.GetAllOrders();
            this.ViewData["orders"] = orders;
            return View(Routers.Manager.Page);
        }

        [HttpGet("search")]
        public IActionResult SearchOrders(string startDate, string endDate, string search)
        {
            var orders = this.OrderService.SearchOrders(startDate, endDate, search);
            this.ViewData["orders"] = orders;
            return View(Routers.SearchOrders.Page);
        }
    }
}