using System;
using System.Web.Mvc;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Users.Notes;
using CalisthenicsSystem.Models.ViewModels.Users.Notes;
using CalisthenicsSystem.Services;
using CalisthenicsSystem.Services.Interfaces;

namespace CalisthenicsSystem.Web.Areas.Users.Controllers
{
    [RouteArea("users")]
    [RoutePrefix("note")]
    [Authorize]
    public class NoteController : Controller
    {
        private INoteService service;

        public NoteController(INoteService service)
        {
            this.service = service;
        }

        [Route("{userName}/index")]
        public ActionResult Index(string userName)
        {
            ViewBag.Username = userName;
            return View();
        }

        [HttpGet]
        [Route("{userName}/create")]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]

        public ActionResult Create(string userName)
        {
            if (this.User.Identity.Name != userName)
            {
                throw new ArgumentException("Може да създадеш дневник само за себе си !");
            }

            if (this.service.IsUserHasNote(userName))
            {
                throw new ArgumentException("Може да имаш само един дневник !");
            }

            ViewBag.Username = userName;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{userName}/create")]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult Create([Bind(Include = "Name, DateCreated")] CreateNoteBm model, string userName)
        {
            if (this.User.Identity.Name != userName)
            {
                throw new ArgumentException("Може да създадеш дневник само за себе си !");
            }

            if (this.service.IsUserHasNote(userName))
            {
                throw new ArgumentException("Може да имаш само един дневник !");
            }

            if (this.ModelState.IsValid)
            {
                this.service.CreateNotFromBm(model, userName);
                return this.RedirectToAction("NoteInfo", "Profile");
            }

            var vm = Mapper.Map<CreateNoteBm, CreateNoteVm>(model);

            ViewBag.Username = userName;
            return this.View(vm);
        }
    }
}