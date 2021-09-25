using Backend.Services.Interface;
using Backend.Utils.Locale;
using Backend.Controllers.DTO;
using Backend.Utils.Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Backend.DAO.Interface;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("/api/auth")]
    public class AuthApiController : Controller
    {
        private readonly IAuthService AuthService;
        private readonly IUserRepository UserRepository;

        public AuthApiController(IAuthService authService, IUserRepository userRepository)
        {
            this.AuthService = authService;
            this.UserRepository = userRepository;
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

            var user = this.UserRepository.GetUserByUsername(body.Username);
            if (user == null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.AuthService.ComparePassword(body.Password, user.Password))
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL);
                return new BadRequestObjectResult(res.getResponse());
            }

            var token = this.AuthService.LoginHandler(user.UserId);

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

        [HttpPost("register")]
        public IActionResult HandleRegister([FromBody] RegisterDTO body)
        {
            var res = new ServerApiResponse<string>();

            ValidationResult result = new RegisterDTOValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var isExistUser = this.UserRepository.GetUserByUsername(body.Username);
            if (isExistUser != null)
            {
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, "username");
                return new BadRequestObjectResult(res.getResponse());
            }

            var user = new User();
            user.UserId = Guid.NewGuid().ToString();
            user.Name = body.Name;
            user.Username = body.Username;
            user.Phone = body.Phone;
            user.Address = body.Address;
            user.Email = body.Email;
            user.CreateDate = DateTime.Now.ToShortDateString();
            user.Role = UserRole.CUSTOMER;
            user.Password = this.AuthService.HashingPassword(body.Password);


            this.AuthService.RegisterHandler(user);

            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_REGISTER_SUCCESS);
            return new ObjectResult(res.getResponse());
        }

    }
}