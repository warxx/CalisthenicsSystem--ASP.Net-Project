using System.Collections.Generic;
using CalisthenicsSystem.Models.BindingModels.Articles;
using CalisthenicsSystem.Models.ViewModels.Articles;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface IArticlesService
    {
        IEnumerable<AllArticlesVm> GetAllArticles();
        ArticleDetailsVm GetArticleDetailsVm(int? articleId);
        void AddArticleFromBm(AddArticleBm model, string userId);
        EditArticleVm GetEditArticleVm(int articleId);
        bool IsArticleExist(int articleId);
        void EditArticleFromBm(EditArticleBm model);
        DeleteArticleVm GetDeleteArticleVm(int articleId);
        void DeleteArticle(int articleId);
        IEnumerable<AllArticlesVm> GetSearchedArticlesVms(string word);
    }
}