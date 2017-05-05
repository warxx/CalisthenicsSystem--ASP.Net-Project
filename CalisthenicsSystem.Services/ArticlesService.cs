using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Articles;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Models.ViewModels.Articles;
using CalisthenicsSystem.Services.Interfaces;
using AllArticlesVm = CalisthenicsSystem.Models.ViewModels.Articles.AllArticlesVm;

namespace CalisthenicsSystem.Services
{
    public class ArticlesService : Service, IArticlesService
    {
        public IEnumerable<AllArticlesVm> GetAllArticles()
        {
            var articles = this.Context.Articles;
            var viewModels = Mapper.Map<IEnumerable<Article>, IEnumerable<AllArticlesVm>>(articles);

            return viewModels;
        }

        public ArticleDetailsVm GetArticleDetailsVm(int? articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            if (article == null)
            {
                return null;
            }

            var viewModel = Mapper.Map<Article, ArticleDetailsVm>(article);

            return viewModel;
        }

        public void AddArticleFromBm(AddArticleBm model, string userId)
        {
            var user = this.Context.Users.Find(userId);

            var article = Mapper.Map<AddArticleBm, Article>(model);
            article.PublishDate = DateTime.Now;
            article.Author = user;

            this.Context.Articles.Add(article);
            this.Context.SaveChanges();
        }

        public EditArticleVm GetEditArticleVm(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            if (article == null)
            {
                return null;
            }

            var vm = Mapper.Map<Article, EditArticleVm>(article);

            return vm;
        }

        public bool IsArticleExist(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            if (article == null)
            {
                return false;
            }

            return true;
        }

        public void EditArticleFromBm(EditArticleBm model)
        {
            var article = this.Context.Articles.Find(model.Id);

            article.Name = model.Name;
            article.Content = model.Content;
            article.ImageUrl = model.ImageUrl;

            this.Context.SaveChanges();
        }

        public DeleteArticleVm GetDeleteArticleVm(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            if (article == null)
            {
                return null;
            }

            var vm = Mapper.Map<Article, DeleteArticleVm>(article);

            return vm;
        }

        public void DeleteArticle(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);
            this.Context.Articles.Remove(article);
            this.Context.SaveChanges();
        }

        public IEnumerable<AllArticlesVm> GetSearchedArticlesVms(string word)
        {
            var articles = this.Context.Articles.Where(n => n.Name.Contains(word));
            var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<AllArticlesVm>>(articles);

            return vms;
        }
    }
}
