using System;

using Microsoft.AspNetCore.Mvc;
using backend.Controllers.DTO;
using backend.Utils.Common;
using backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Web;
namespace backend.Controllers
{

    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {

            return View(Routers.Login.page);
        }


        [HttpPost("login")]
        public IActionResult handleLogin(string username, string password)
        {
            var input = new LoginDTO() { username = username, password = password };
            var token = this.authService.loginHandler(input, this.ViewData);

            if (token == null)
            {
                return View(Routers.Login.page);
            }
            this.HttpContext.Response.Cookies.Append("auth-token", token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            return Redirect(Routers.Home.link);
        }


        [HttpGet("register")]
        public IActionResult Register()
        {
            return View(Routers.Register.page);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {

            this.HttpContext.Response.Cookies.Append("auth-token", "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            return Redirect(Routers.Login.link);
        }


        [HttpPost("register")]
        public IActionResult handleRegister(string name, string username, string password, string confirmPassword, string email, string phone, string address)
        {
            var input = new RegisterDTO()
            {
                name = name,
                username = username,
                password = password,
                confirmPassword = confirmPassword,
                email = email,
                phone = phone,
                address = address,
            };

            var isValid = this.authService.registerHandler(input, this.ViewData);

            if (!isValid)
            {
                return View(Routers.Register.page);
            }

            return Redirect(Routers.Login.link);
        }

    }
}