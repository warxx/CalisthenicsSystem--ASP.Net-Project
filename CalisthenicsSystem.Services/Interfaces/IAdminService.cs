using System.Collections.Generic;
using CalisthenicsSystem.Models.ViewModels.Admin;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<UserVm> GetAllUsers();
        IEnumerable<ArticleVm> GetArticlesVms();
        IEnumerable<ExerciseVm> GetExercisesVms();
        IEnumerable<AllMessagesVm> GetContactsVms();
        SetRoleVm GetSetRoleVm(string userName);
        IEnumerable<ArticleVm> GetSearchedArticlesVms(string word, string category, string type);
        IEnumerable<ExerciseVm> GetSearchedExercisesVms(string word, string category, string type);
        IEnumerable<UserVm> GetSearchedUsersVms(string word, string category, string type);
        MessageVm GetMessageDetailsVm(int id);
    }
}