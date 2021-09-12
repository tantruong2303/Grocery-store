using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Controllers.DTO;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Backend.Pipe;

namespace Backend.Controllers
{
    [Route("user")]
    [ServiceFilter(typeof(AuthGuard))]
    public class UserController : Controller
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }

        [HttpGet("")]
        public IActionResult GetUser()
        {
            return View(Routers.User.Page);
        }

        [HttpGet("password")]
        public IActionResult UpdatePassword()
        {
            return View(Routers.UpdatePassword.Page);
        }

        [HttpPost("password")]
        public IActionResult HandleUpdatePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {
            var input = new UpdatePasswordDTO()
            {
                oldPassword = oldPassword,
                newPassword = newPassword,
                confirmNewPassword = confirmNewPassword
            };

            var isUpdate = this.UserService.UpdatePasswordHandler(input, this.ViewData);
            if (!isUpdate)
            {
                return View(Routers.UpdatePassword.Page);
            }

            this.HttpContext.Response.Cookies.Append("auth-token", "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            return Redirect(Routers.Login.Link);
        }

        [HttpGet("info")]
        public IActionResult UpdateUserInfo()
        {
            return View(Routers.UpdateUserInfo.Page);
        }

        [HttpPost("info")]
        public IActionResult HandleUpdateUserInfo(string name, string email, string phone, string address)
        {
            var input = new UpdateUserInfoDTO()
            {
                name = name,
                email = email,
                phone = phone,
                address = address
            };

            var isUpdate = this.UserService.UpdateUserInfoHandler(input, this.ViewData);

            if (!isUpdate)
            {
                return View(Routers.UpdateUserInfo.Page);
            }

            return Redirect(Routers.Home.Link);
        }
    }
}