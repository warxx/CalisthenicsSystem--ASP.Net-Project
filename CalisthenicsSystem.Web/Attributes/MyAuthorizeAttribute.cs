using System.Linq;
using System.Web.Mvc;

namespace CalisthenicsSystem.Web.Attributes
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');


            if (filterContext.HttpContext.Request.IsAuthenticated &&
                    !roles.Any(x => filterContext.HttpContext.User.IsInRole(x)))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Errors/Unauthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }

        }
    }
}