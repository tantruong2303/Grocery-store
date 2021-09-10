using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Controllers.DTO;
using backend.Utils.Common;
using backend.Utils.Validator;
using backend.Services;

namespace backend.Controllers
{
    public class AuthGuard : IActionFilter
    {

        private readonly AuthController authController;
        public AuthGuard(AuthController authController)
        {
            this.authController = authController;
            // this.jwtService = jwtService;
            // this.userService = userService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {


            context.Result = new ViewResult
            {
                ViewName = "/Views/Auth/Register.cshtml",
            };
            return;
            // return;
            // var res = new ServerResponse<object>();
            // var cookies = new Dictionary<string, string>();
            // var values = ((string)context.HttpContext.Request.Headers["Cookie"]).Split(',', ';');


            // foreach (var parts in values)
            // {
            //     var cookieArray = parts.Trim().Split('=');
            //     cookies.Add(cookieArray[0], cookieArray[1]);
            // }
            // var outValue = "";
            // if (!cookies.TryGetValue("auth-token", out outValue))
            // {

            //     res.setErrorMessage(ErrorMessageKey.Error_NotAllow);
            //     context.Result = new UnauthorizedObjectResult(res.getResponse());
            //     return;
            // }
            // try
            // {
            //     var token = this.jwtService.VerifyToken(cookies["auth-token"]).Split(";");

            //     if (token[0] == null)
            //     {
            //         res.setErrorMessage(ErrorMessageKey.Error_NotAllow);
            //         context.Result = new UnauthorizedObjectResult(res.getResponse());
            //         return;

            //     }
            //     var user = this.userService.getUserById(token[0]);
            //     if (user == null)
            //     {
            //         res.setErrorMessage(ErrorMessageKey.Error_NotAllow);
            //         context.Result = new UnauthorizedObjectResult(res.getResponse());
            //         return;
            //     }
            //     Controller controller = context.Controller as Controller;
            //     controller.ViewData["user"] = user;

            //     var objOut = new Object();

            //     // check user's role
            //     if (context.ActionArguments.TryGetValue("roles", out objOut))
            //     {
            //         UserRole[] roles = context.ActionArguments["roles"] as UserRole[];
            //         if (!roles.Contains(user.role))
            //         {
            //             res.setErrorMessage(ErrorMessageKey.Error_NotAllow);
            //             context.Result = new UnauthorizedObjectResult(res.getResponse());
            //             return;
            //         }
            //     }


            //     // check user status
            //     if (user.status == UserStatus.DISABLE)
            //     {
            //         res.setErrorMessage(ErrorMessageKey.Error_NotAllow);
            //         context.Result = new UnauthorizedObjectResult(res.getResponse());
            //         return;
            //     }
            // }
            // catch (Exception error)
            // {
            //     Console.WriteLine(error);

            //     //k du do dai 
            //     // can fix sau
            //     res.setErrorMessage(ErrorMessageKey.Error_NotAllow);
            //     context.Result = new UnauthorizedObjectResult(res.getResponse());
            //     return;
            // }
        }
    }
}