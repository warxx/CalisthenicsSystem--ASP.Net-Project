using System.Web.Mvc;

namespace CalisthenicsSystem.Web.Areas.Users.Controllers
{
    [RouteArea("users")]
    [RoutePrefix("gallery")]
    [Authorize]
    public class GalleriesController : Controller
    {
        [HttpGet]
        [Route("{userName}")]
        public ActionResult Index(string userName)
        {
            ViewBag.Username = userName;
            return View();
        }
    }
}