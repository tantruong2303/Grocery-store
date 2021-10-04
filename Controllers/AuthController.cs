using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Backend.Pipe;
using Backend.Models;

namespace Backend.Controllers
{

    [Route("auth")]
    [ServiceFilter(typeof(UserFilter))]
    public class AuthController : Controller
    {
        private readonly IAuthService AuthService;

        public AuthController(IAuthService authService)
        {
            this.AuthService = authService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var user = (User)this.ViewData["user"];
            if (user != null)
            {
                return Redirect(Routers.Home.Link);
            }
            return View(Routers.Login.Page);
        }


        [HttpGet("register")]
        public IActionResult Register()
        {
            var user = (User)this.ViewData["user"];
            if (user != null)
            {
                return Redirect(Routers.Home.Link);
            }
            return View(Routers.Register.Page);
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
            this.HttpContext.Session.Clear();
            return Redirect(Routers.Login.Link + "?message=logout success");
        }



    }
}