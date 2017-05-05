using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CalisthenicsSystem.Models.BindingModels.Users;
using CalisthenicsSystem.Services;
using CalisthenicsSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace CalisthenicsSystem.Web.Areas.Users.Controllers
{
    [Authorize]
    [RouteArea("users")]
    [RoutePrefix("profile")]
    public class ProfileController : Controller
    {
        private IUsersService service;

        public ProfileController(IUsersService service)
        {
            this.service = service;
        }

        [Route("overview/{userName}")]
        [HttpGet]
        public ActionResult Overview(string userName)
        {
            var viewModel = this.service.GetProfileOverviewVm(userName);
            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.Username = userName;
            return View(viewModel);
        }

        [HttpGet]
        [Route("follow/{userName}")]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult Follow(string userName)
        {
            if (this.User.Identity.Name == userName)
            {
                throw new ArgumentException("Не можеш да се последваш !");
            }

            var viewModel = this.service.GetFollowUserVm(userName);

            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.Username = userName;
            return this.View(viewModel);
        }

        [HttpPost, ActionName("Follow")]
        [Route("follow/{userName}")]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult FollowConfirmed(string userName)
        {
            if (this.User.Identity.Name.ToLower() == userName)
            {
                throw new ArgumentException("Не можеш да се последваш !");
            }

            if (!this.service.IsUserExist(userName))
            {
                return this.HttpNotFound();
            }

            string following = userName;
            string follower = this.User.Identity.GetUserName();

            if (this.service.IsFollowerExist(following, follower))
            {
                throw new ArgumentException("Вече си последвал този потребител !");
            }

            this.service.FollowUser(following, follower);

            ViewBag.Username = userName;
            return RedirectToAction("Overview", new {userName = $"{userName}"});
        }

        [HttpGet]
        [Route("followers/{userName}")]
        public ActionResult Followers(string userName)
        {
            var viewModels = this.service.GetFollowersVm(userName);

            if (viewModels == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.Username = userName;
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("followings/{userName}")]
        public ActionResult Followings(string userName)
        {
            var viewModels = this.service.GetFollowingsVm(userName);

            if (viewModels == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.Username = userName;
            return this.View(viewModels);
        }

        [HttpGet]
        [Route("edit/{userName}")]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult Edit(string userName)
        {
            if (this.User.Identity.Name.ToLower() != userName)
            {
                throw new ArgumentException("Може да променяш само собствения си профил !");
            }

            var viewModel = this.service.GetEditProfileVm(userName);

            ViewBag.Username = userName;
            return this.View(viewModel);
        }

        [Route("edit/{userName}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(ArgumentException), View = "Errors/ArgumentExcError")]
        public ActionResult Edit(
            [Bind(Include = "UserName, Name, BirthDate, BirthPlace, AvatarPath, Gender")] EditProfileBm model)
        {
            if (this.User.Identity.Name.ToLower() != model.UserName)
            {
                throw new ArgumentException("Може да променяш само собствения си профил !");
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
                    string path = Path.Combine(Server.MapPath("~/Content/images/avatars"), fileName);
                    file.SaveAs(path);

                    this.service.EditProfileBm(model, fileName);
                    return this.RedirectToAction("Overview", new {userName = $"{model.UserName}"});
                }

                this.service.EditProfileBm(model, null);
                return this.RedirectToAction("Overview", new { userName = $"{model.UserName}" });
            }

            var viewModel = this.service.GetEditProfileVm(model.UserName);

            ViewBag.Username = model.UserName;
            return this.View(viewModel);
        }

        [Route("note/{userName}")]
        public ActionResult NoteInfo(string userName)
        {
            if (!this.service.IsUserExist(userName))
            {
                return this.HttpNotFound();
            }

            var vm = this.service.GetUserNoteVm(userName);

            if (vm == null)
            {
                ViewBag.Username = userName;
                return this.View("NoNote");
            }

            ViewBag.Username = userName;
            return this.View(vm);
        }
    }
}