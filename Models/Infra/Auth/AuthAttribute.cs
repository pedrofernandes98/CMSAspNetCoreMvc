using Microsoft.AspNetCore.Mvc.Filters;

namespace cmsMvc.Models.Infra.Auth
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(string.IsNullOrEmpty(context.HttpContext.Request.Cookies["admin"]))
            {
                context.HttpContext.Response.Redirect("/login");
                return;
            }

            base.OnActionExecuting(context);
        }
        
    }
}