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
        public IActionResult Order(int pageIndex = 0, int pageSize = 12)
        {

            var user = (User)this.ViewData["user"];
            var (orders, total) = this.OrderService.GetOrders(user.UserId, pageIndex, pageSize);
            this.ViewData["orders"] = orders;
            this.ViewData["total"] = total;
            return View(Routers.Order.Page);
        }

        [HttpGet("detail")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult OrderDetail(string orderId, int pageIndex = 0, int pageSize = 1000)
        {
            var (items, count) = this.OrderService.GetOrderDetail(orderId, pageIndex, pageSize);
            this.ViewData["items"] = items;
            this.ViewData["total"] = count;
            return View(Routers.OrderDetail.Page);
        }


        [HttpGet("manager")]
        [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult GetAllOrders(string startDate, string endDate, string search, int pageIndex = 0, int pageSize = 12)
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
                var (orders, total) = this.OrderService.SearchOrders(startDate, endDate, search, pageIndex, pageSize);
                this.ViewData["orders"] = orders;
                this.ViewData["total"] = total;
                return View(Routers.Manager.Page);
            }
            catch (System.Exception)
            {

                var query = $"?startDate={firstDate}&endDate={lastDate}&search=";
                return Redirect(Routers.Manager.Link + query);
            }


        }

    }
}