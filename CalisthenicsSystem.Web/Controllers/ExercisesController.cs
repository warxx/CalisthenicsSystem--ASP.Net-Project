using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Exercises;
using CalisthenicsSystem.Models.ViewModels.Exercises;
using CalisthenicsSystem.Services.Interfaces;
using CalisthenicsSystem.Web.Attributes;
using Microsoft.AspNet.Identity;

namespace CalisthenicsSystem.Web.Controllers
{
    [RoutePrefix("exercises")]
    public class ExercisesController : Controller
    {
        private IExercisesService service;

        public ExercisesController(IExercisesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("types/{type}")]
        [HttpGet]
        public ActionResult All(string type)
        {
            var viewModels = this.service.GetAllExercises(type);

            if (viewModels == null)
            {
                return new HttpNotFoundResult();
            }

            return View(viewModels);
        }

        [Route("add")]
        [HttpGet]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        public ActionResult Add()
        {
            return this.View();
        }

        [Route("add")]
        [HttpPost]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult Add([Bind(Include = "Name, Content, ImageUrl, YoutubeUrl, MuscleGroup")] AddExerciseBm model)
        {
            if (this.ModelState.IsValid)
            {
                HttpPostedFileBase file = this.Request.Files["MyFile"];

                if (file == null)
                {
                    throw new ArgumentException("Трябва да качиш задължително снимка !");
                }

                if (file.ContentType != "image/jpeg")
                {
                    throw new ArgumentException("Снимката трябва да е в jpg/jpeg формат !");
                }

                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/images/exercises"), fileName);
                file.SaveAs(path);

                var userId = this.User.Identity.GetUserId();
                this.service.AddExerciseFromBm(model, userId, fileName);
                return this.RedirectToAction("Index", "Exercises");
            }

            var viewModel = Mapper.Map<AddExerciseBm, AddExerciseVm>(model);
            return this.View(viewModel);
        }

        [HttpGet]
        [Route("details/{exerciseId:int}")]
        public ActionResult Details(int? exerciseId)
        {
            var viewModel = this.service.GetExerciseDetailsVm(exerciseId);

            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        [Route("edit/{exerciseId:int}")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        public ActionResult Edit(int exerciseId)
        {
            var vm = this.service.GetEditExerciseVm(exerciseId);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{exerciseId:int}")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult Edit([Bind(Include = "Id, Name, Content, ImageUrl, YoutubeUrl")] EditExerciseBm model)
        {
            if (!this.service.IsExerciseExist(model.Id))
            {
                return this.HttpNotFound();
            }

            HttpPostedFileBase file = this.Request.Files["MyFile"];

            if (this.ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    if (file.ContentType != "image/jpeg")
                    {
                        throw new ArgumentException("Снимката трябва да е в jpg/jpeg формат !");
                    }

                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/images/exercises"), fileName);
                    file.SaveAs(path);

                    this.service.EditExerciseFromBm(model, fileName);
                    return this.RedirectToAction("Details", "Exercises", new {exerciseId = model.Id});
                }

                this.service.EditExerciseFromBm(model, null);
                return this.RedirectToAction("Details", "Exercises", new { exerciseId = model.Id });
                
            }

            var viewModel = this.service.GetEditExerciseVm(model.Id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Route("delete/{exerciseId:int}")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        public ActionResult Delete(int exerciseId)
        {
            var vm = this.service.GetDeleteExerciseVm(exerciseId);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{exerciseId:int}")]
        [ActionName("Delete")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int exerciseId)
        {
            if (!this.service.IsExerciseExist(exerciseId))
            {
                return this.HttpNotFound();
            }

            this.service.DeleteExercise(exerciseId);

            return this.RedirectToAction("Index", "Exercises");
        }

        [Route("search")]
        public ActionResult Search(string word)
        {
            var vms = this.service.GetSearchedExercisesVms(word);
            return this.PartialView("_AllExercises", vms);
        }
    }
}