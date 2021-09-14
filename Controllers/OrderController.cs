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

        [HttpGet("/detail")]
        public IActionResult OrderDetail(string orderId)
        {
            var items = this.OrderService.GetOrderDetail(orderId);
            this.ViewData["items"] = items;
            return View(Routers.OrderDetail.Page);
        }

        [HttpGet("manager")]
        public IActionResult Manager()
        {
            var user = (User)this.ViewData["user"];
            var orders = this.OrderService.GetOrders(user.UserId);
            this.ViewData["orders"] = orders;
            return View(Routers.Order.Page);
        }
    }
}