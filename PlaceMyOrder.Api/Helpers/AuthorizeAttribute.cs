using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Infrastructure.Utils;

namespace PlaceMyOrder.Api.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User?)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = Messages.Unauthorized }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
