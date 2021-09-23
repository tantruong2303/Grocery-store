using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Controllers.DTO;
using Backend.Utils.Common;
using grocery_store.Utils.Common;
using FluentValidation.Results;
using Backend.Utils.Locale;

namespace Backend.Controllers
{
    [Route("/api/auth")]
    public class AuthApiController : Controller
    {
        private readonly IAuthService AuthService;

        public AuthApiController(IAuthService authService)
        {
            this.AuthService = authService;
        }

        [HttpPost("login")]
        public IActionResult HandleLogin([FromBody] LoginDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new LoginDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var token = this.AuthService.LoginHandler(body, this.ViewData);

            if (token == null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL);
                return new BadRequestObjectResult(res.getResponse());
            }

            this.HttpContext.Response.Cookies.Append("auth-token", token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_LOGIN_SUCCESS);
            return new ObjectResult(res.getResponse());
        }
    }
}