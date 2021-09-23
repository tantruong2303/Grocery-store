using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Controllers.DTO;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace Backend.Controllers
{

    [Route("auth")]
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

            return View(Routers.Login.Page);
        }


        [HttpGet("register")]
        public IActionResult Register()
        {
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

            return Redirect(Routers.Login.Link + "?message=logout success");
        }



    }
}