using System.Collections.Generic;
using CalisthenicsSystem.Models.BindingModels.Users;
using CalisthenicsSystem.Models.ViewModels.Users;
using CalisthenicsSystem.Models.ViewModels.Users.Profiles;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface IUsersService
    {
        ProfileOverviewVm GetProfileOverviewVm(string userName);
        FollowUserVm GetFollowUserVm(string userName);
        bool IsUserExist(string userName);
        void FollowUser(string following, string follower);
        bool IsFollowerExist(string following, string follower);
        IEnumerable<FollowsVm> GetFollowersVm(string userName);
        IEnumerable<FollowsVm> GetFollowingsVm(string userName);
        EditProfileVm GetEditProfileVm(string userName);
        void EditProfileBm(EditProfileBm model, string filemName);
        IEnumerable<AllUsersVm> GetAllUsers();
        UserNoteVm GetUserNoteVm(string userName);
    }
}