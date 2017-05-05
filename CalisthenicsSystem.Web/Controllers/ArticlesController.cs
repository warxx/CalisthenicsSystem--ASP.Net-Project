using System.Web.Mvc;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Articles;
using CalisthenicsSystem.Models.ViewModels.Articles;
using CalisthenicsSystem.Services;
using CalisthenicsSystem.Services.Interfaces;
using CalisthenicsSystem.Web.Attributes;
using Microsoft.AspNet.Identity;

namespace CalisthenicsSystem.Web.Controllers
{
    [RoutePrefix("articles")]
    public class ArticlesController : Controller
    {
        private IArticlesService service;

        public ArticlesController(IArticlesService service)
        {
            this.service = service;
        }

        // GET: Articles
        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            var vms = this.service.GetAllArticles();

            return View(vms);
        }

        [HttpGet]
        [Route("details/{articleId:int}")]
        public ActionResult Details(int? articleId)
        {
            var viewModel = this.service.GetArticleDetailsVm(articleId);

            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        [Route("add")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Name, Content, ImageUrl")] AddArticleBm model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                this.service.AddArticleFromBm(model, userId);
                return this.RedirectToAction("All", "Articles");

            }

            var viewModel = Mapper.Map<AddArticleBm, AddArticleVm>(model);
            return this.View(viewModel);
        }

        [HttpGet]
        [Route("edit/{articleId:int}")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        public ActionResult Edit(int articleId)
        {
            var vm = this.service.GetEditArticleVm(articleId);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/{articleIdl:int}")]
        [MyAuthorize(Roles = "BlogAuthor, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Content, ImageUrl")] EditArticleBm model)
        {
            if (!this.service.IsArticleExist(model.Id))
            {
                return this.HttpNotFound();
            }

            if (this.ModelState.IsValid)
            {
                this.service.EditArticleFromBm(model);
                return this.RedirectToAction("Details", "Articles", new { articleId = model.Id });
            }

            var viewModel = this.service.GetEditArticleVm(model.Id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Route("delete/{articleId:int}")]
        [MyAuthorize(Roles = "Admin")]
        public ActionResult Delete(int articleId)
        {
            var vm = this.service.GetDeleteArticleVm(articleId);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{articleId:int}")]
        [ActionName("Delete")]
        [MyAuthorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int articleId)
        {
            if (!this.service.IsArticleExist(articleId))
            {
                return this.HttpNotFound();
            }

            this.service.DeleteArticle(articleId);

            return this.RedirectToAction("All", "Articles");
        }

        [Route("search")]
        [Authorize]
        public ActionResult Search(string word)
        {
            var vms = this.service.GetSearchedArticlesVms(word);
            return this.PartialView("_AllArticles", vms);
        }
    }
}