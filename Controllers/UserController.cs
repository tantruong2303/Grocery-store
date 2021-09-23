using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Services.Interface;
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

        [HttpGet("info")]
        public IActionResult UpdateUserInfo()
        {
            return View(Routers.UpdateUserInfo.Page);
        }

    }
}