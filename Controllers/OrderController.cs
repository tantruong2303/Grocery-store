using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Backend.Pipe;
using Backend.Models;



namespace Backend.Controllers
{
    [Route("order")]

    public class OrderController : Controller
    {
        private readonly IOrderService OrderService;
        private const string CartSession = "CartSession";
        private readonly ICartService CartService;
        private readonly IProductService ProductService;
        public OrderController(IOrderService orderService, ICartService cartService, IProductService productService)
        {
            this.OrderService = orderService;
            this.CartService = cartService;
            this.ProductService = productService;
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

        [HttpGet("detail")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult OrderDetail(string orderId, int pageIndex = 0, int pageSize = 1)
        {
            var (items, count) = this.OrderService.GetOrderDetail(orderId, pageIndex, pageSize);
            this.ViewData["items"] = items;
            this.ViewData["count"] = count;
            return View(Routers.OrderDetail.Page);
        }


        [HttpGet("manager")]
        [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult GetAllOrders(string startDate, string endDate, string search)
        {
            var now = DateTime.Now;
            string lastDate = now.AddDays(1).ToString("yyyy-MM-dd");
            string firstDate = now.AddYears(-1).ToString("yyyy-MM-dd");

            if (startDate == null || endDate == null)
            {
                var query = $"?startDate={firstDate}&endDate={lastDate}&search=";
                return Redirect(Routers.Manager.Link + query);
            }

            try
            {
                var orders = this.OrderService.SearchOrders(startDate, endDate, search);
                this.ViewData["orders"] = orders;
                return View(Routers.Manager.Page);
            }
            catch (System.Exception)
            {
                Console.WriteLine("ok");
                var query = $"?startDate={firstDate}&endDate={lastDate}&search=";
                return Redirect(Routers.Manager.Link + query);
            }


        }

    }
}