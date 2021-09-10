using System.Reflection;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Controllers.DTO;
using backend.Utils.Common;
using backend.Utils.Validator;
using backend.Services;

namespace backend.Controllers
{

    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserService userService;

        public AuthController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            Console.WriteLine("calllllllllllllllll");
            return View(Routers.Register.page);
        }


        [HttpPost("register")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult handleRegister(string username, string password)
        {

            Console.WriteLine("call me");
            var input = new RegisterDTO() { username = username, password = password };

            Boolean isValid = this.userService.registerHandler(input, this.ViewData);

            return View(Routers.Register.page);
        }
    }
}