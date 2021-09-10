
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Utils.Common;
using backend.Pipe;

namespace backend.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Index()
        {

            this.ViewData["Title"] = "hello";
            return View(Routers.Home.page);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
