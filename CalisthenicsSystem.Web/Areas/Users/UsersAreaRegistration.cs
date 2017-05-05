using System.Web.Mvc;

namespace CalisthenicsSystem.Web.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            context.Routes.MapMvcAttributeRoutes();

            //context.MapRoute(
            //    "Users_default",
            //    "{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}