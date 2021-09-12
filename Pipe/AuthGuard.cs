using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Backend.Controllers.DTO;
using Backend.Utils.Common;
using Backend.Utils.Validator;
using Backend.Services;
using Backend.DAO.Interface;
using Backend.Utils.Interface;
using Backend.Utils.Locale;

namespace Backend.Pipe
{
    public class AuthGuard : IActionFilter
    {

        private readonly IJwtService jwtService;
        private readonly IUserRepository userRepository;
        public AuthGuard(IJwtService jwtService, IUserRepository userRepository)
        {

            this.jwtService = jwtService;
            this.userRepository = userRepository;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public bool guardHandler(ActionExecutingContext context)
        {

            try
            {
                var cookies = new Dictionary<string, string>();
                var values = ((string)context.HttpContext.Request.Headers["Cookie"]).Split(',', ';');


                foreach (var parts in values)
                {
                    var cookieArray = parts.Trim().Split('=');
                    cookies.Add(cookieArray[0], cookieArray[1]);
                }

                if (!cookies.TryGetValue("auth-token", out _))
                {
                    return false;
                }
                var token = this.jwtService.VerifyToken(cookies["auth-token"]).Split(";");

                if (token[0] == null)
                {
                    return false;
                }
                var user = this.userRepository.GetUserById(token[0]);
                if (user == null)
                {
                    return false;
                }
                Controller controller = context.Controller as Controller;
                controller.ViewData["user"] = user;

                // check user's role
                if (context.ActionArguments.TryGetValue("roles", out _))
                {
                    UserRole[] roles = context.ActionArguments["roles"] as UserRole[];
                    if (!roles.Contains(user.role))
                    {
                        return false;
                    }
                }


                return true;

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            bool isValid = this.guardHandler(context);
            if (!isValid)
            {
                Controller controller = context.Controller as Controller;
                ServerResponse.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_ALLOW_ACTION, controller.ViewData);
                context.Result = new ViewResult
                {
                    ViewName = Routers.Login.Page,
                };
                return;

            }
        }
    }
}