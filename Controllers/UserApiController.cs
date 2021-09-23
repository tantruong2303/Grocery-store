using FluentValidation.Results;
using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Pipe;
using Backend.Models;
using Backend.Services.Interface;
using Backend.Controllers.DTO;
using grocery_store.Utils.Common;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Microsoft.AspNetCore.Http;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ServiceFilter(typeof(AuthGuard))]
    public class UserApiController : Controller
    {
        private readonly IUserService UserService;
        private readonly IAuthService AuthService;

        public UserApiController(IUserService userService, IAuthService authService)
        {
            this.UserService = userService;
            this.AuthService = authService;
        }

        [HttpPut("password")]
        public IActionResult HandleUpdatePassword([FromBody] UpdatePasswordDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new UpdatePasswordDTOValidator().Validate(body);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            User user = (User)ViewData["user"];

            if (!AuthService.ComparePassword(body.oldPassword, user.Password))
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_OLD_PASSWORD_NOT_CORRECT);
                return new BadRequestObjectResult(res.getResponse());
            }

            user.Password = AuthService.HashingPassword(body.newPassword);
            this.UserService.UpdatePasswordHandler(user);

            this.HttpContext.Response.Cookies.Append("auth-token", "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1),
                SameSite = SameSiteMode.None,
                Secure = true

            });
            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Password");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut("info")]
        public IActionResult HandleUpdateUserInfo([FromBody] UpdateUserInfoDTO body)
        {
            var res = new ServerApiResponse<string>();
            ValidationResult result = new UpdateUserInfoDTOValidator().Validate(body);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            User user = (User)ViewData["user"];
            user.Name = body.name;
            user.Email = body.email;
            user.Phone = body.phone;
            user.Address = body.address;

            this.UserService.UpdateUserInfoHandler(user);

            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_UPDATE_SUCCESS);
            return new ObjectResult(res.getResponse());
        }
    }
}