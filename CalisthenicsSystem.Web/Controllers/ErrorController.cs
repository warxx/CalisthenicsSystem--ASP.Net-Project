using System.Web.Mvc;

namespace CalisthenicsSystem.Web.Controllers
{
    [RoutePrefix("Error")]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Error");
        }

        [Route("NotFound")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }
    }
}