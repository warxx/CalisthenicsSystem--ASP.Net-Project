using System.Web.Mvc;
using CalisthenicsSystem.Services;
using CalisthenicsSystem.Services.Interfaces;
using CalisthenicsSystem.Web.Attributes;

namespace CalisthenicsSystem.Web.Areas.Users.Controllers
{
    [RouteArea("users")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUsersService service;

        public HomeController(IUsersService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            var vms = this.service.GetAllUsers();

            return View(vms);
        }
    }
}