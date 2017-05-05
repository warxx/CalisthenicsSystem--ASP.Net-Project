using System;
using System.Web;
using System.Web.Mvc;
using CalisthenicsSystem.Models.BindingModels.Admin;
using CalisthenicsSystem.Services.Interfaces;
using CalisthenicsSystem.Web.Attributes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CalisthenicsSystem.Web.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [MyAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [Route("index")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("users/all")]
        public ActionResult AllUsers()
        {
            var vms = this.service.GetAllUsers();

            return this.View(vms);
        }

        [HttpGet]
        [Route("articles/all")]
        public ActionResult AllArticles()
        {
            var vms = this.service.GetArticlesVms();

            return this.View(vms);
        }

        [HttpGet]
        [Route("exercises/all")]
        public ActionResult AllExercises()
        {
            var vms = this.service.GetExercisesVms();

            return this.View(vms);
        }

        [HttpGet]
        [Route("users/setrole/{userName}")]
        public ActionResult SetRole(string userName)
        {

            var vm = this.service.GetSetRoleVm(userName);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("users/setrole/{userName}")]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult SetRole([Bind(Include = "RoleName, UserName")] SetRoleBm model)
        {
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(model.UserName);

            if (user == null)
            {
                return this.HttpNotFound();
            }

            if (userManager.IsInRole(user.Id, model.RoleName))
            {
                throw new ArgumentException($"{model.UserName} вече е {model.RoleName} !");
            }

            userManager.AddToRole(user.Id, model.RoleName);
            return RedirectToAction("AllUsers");
        }

        [HttpGet]
        [Route("contacts/all")]
        public ActionResult AllContacts()
        {
            var vms = this.service.GetContactsVms();

            return this.View(vms);
        }

        [HttpGet]
        [Route("contacts/details/{id:int}")]
        public ActionResult Message(int id)
        {
            var vm = this.service.GetMessageDetailsVm(id);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [Route("articles/search")]
        public ActionResult SearchArticle(string word, string category, string type)
        {
            var vms = this.service.GetSearchedArticlesVms(word, category, type);
            return this.PartialView("_AllArticlesPartial", vms);
        }

        [Route("exercises/search")]
        public ActionResult SearchExercise(string word, string category, string type)
        {
            var vms = this.service.GetSearchedExercisesVms(word, category, type);
            return this.PartialView("_AllExercisesPartial", vms);
        }

        [Route("users/search")]
        public ActionResult SearchUser(string word, string category, string type)
        {
            var vms = this.service.GetSearchedUsersVms(word, category, type);
            return this.PartialView("_AllUsersPartial", vms);
        }
    }
}