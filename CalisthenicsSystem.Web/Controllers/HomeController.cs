using System.Web.Mvc;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Home;
using CalisthenicsSystem.Models.ViewModels.Home;
using CalisthenicsSystem.Services;
using CalisthenicsSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace CalisthenicsSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        

        [Route("")]
        public ActionResult Index()
        {
            var vms = this.service.GetArticlesVms();

            return this.View(vms);
        }

        [HttpGet]
        [Route("contacts")]
        [Authorize]
        public ActionResult Contacts()
        {
            return this.View();
        }

        [HttpPost]
        [Route("contacts")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Contacts([Bind(Include = "Title, Content, Email, PublishDate")] ContactsBm model)
        {
            if (this.ModelState.IsValid)
            {
                var userName = this.User.Identity.GetUserName();

                this.service.AddMessageFromBm(model, userName);
                return this.RedirectToAction("Index", "Home");
            }

            var vm = Mapper.Map<ContactsBm, ContactsVm>(model);
            return this.View(vm);
        }
    }
}