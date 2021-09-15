using Microsoft.AspNetCore.Mvc.Filters;
using Backend.Models;

namespace Backend.Pipe
{
    public class RoleGuardAttribute : ActionFilterAttribute
    {
        private UserRole[] roles;
        public RoleGuardAttribute(UserRole[] roles)
        {
            this.roles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["roles"] = this.roles;
        }
    }
}