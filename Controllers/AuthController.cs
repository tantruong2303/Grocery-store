
using Microsoft.AspNetCore.Mvc;
using backend.Controllers.DTO;
using backend.Utils.Common;
using backend.Services.Interface;
namespace backend.Controllers
{

    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {

            return View(Routers.Login.page);
        }


        [HttpPost("login")]
        public IActionResult handleRegister(string username, string password)
        {
            var input = new LoginDTO() { username = username, password = password };
            var user = this.userService.loginHandler(input, this.ViewData);
            if (user == null)
            {
                return View(Routers.Login.page);
            }

            return View(Routers.Home.page);
        }
    }
}