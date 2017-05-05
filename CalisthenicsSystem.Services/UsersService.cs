using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Users;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Models.ViewModels.Users.Profiles;
using CalisthenicsSystem.Services.Interfaces;
using AllUsersVm = CalisthenicsSystem.Models.ViewModels.Users.AllUsersVm;

namespace CalisthenicsSystem.Services
{
    
    public class UsersService : Service, IUsersService
    {

        public ProfileOverviewVm GetProfileOverviewVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(n => n.UserName == userName);

            if (user == null)
            {
                return null;
            }
            
            var viewModel = Mapper.Map<ApplicationUser, ProfileOverviewVm>(user);
            if (user.BirthDate.HasValue)
            {
                viewModel.BirthDate = user.BirthDate.Value.ToShortDateString();
            }
            
            return viewModel;
        }

        public FollowUserVm GetFollowUserVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var viewModel = new FollowUserVm()
            {
                UserName = user.UserName
            };

            return viewModel;
        }

        public bool IsUserExist(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public void FollowUser(string following, string follower)
        {
            var followerUser = this.Context.Users.FirstOrDefault(u => u.UserName == follower);
            var followingUser = this.Context.Users.FirstOrDefault(u => u.UserName == following);
            
            followingUser.Followers.Add(followerUser);
            this.Context.Entry(followingUser).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public bool IsFollowerExist(string following, string follower)
        {
          //  var followerUser = this.Context.Users.FirstOrDefault(u => u.UserName == follower);
            var followingUser = this.Context.Users.FirstOrDefault(u => u.UserName == following);

            if (followingUser.Followers.Any(u => u.UserName == follower))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<FollowsVm> GetFollowersVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var followers = user.Followers.ToList();
            var viewModels = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<FollowsVm>>(followers);
            return viewModels;
        }

        public IEnumerable<FollowsVm> GetFollowingsVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var followers = user.Following.ToList();
            var viewModels = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<FollowsVm>>(followers);
            return viewModels;
        }

        public EditProfileVm GetEditProfileVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            var viewModel = Mapper.Map<ApplicationUser, EditProfileVm>(user);

            return viewModel;
        }

        public void EditProfileBm(EditProfileBm model, string filemName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == model.UserName);

            user.Name = string.IsNullOrEmpty(model.Name) ? "Няма информация" : model.Name;
            user.BirthPlace = string.IsNullOrEmpty(model.BirthPlace) ? "Няма информация" : model.BirthPlace;
            user.BirthDate = model.BirthDate;
            user.Gender = model.Gender;

            if (filemName != null)
            {
                user.AvatarPath = filemName;
            }

            this.Context.SaveChanges();
        }

        public IEnumerable<AllUsersVm> GetAllUsers()
        {
            var users = this.Context.Users.ToList();

            var vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AllUsersVm>>(users);

            return vms;
        }

        public UserNoteVm GetUserNoteVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(x=> x.UserName == userName);
            var note = user.Note;

            if (note == null)
            {
                return null;
            }

            var vm = Mapper.Map<Note, UserNoteVm>(note);
            vm.Views = 0;

            return vm;
        }
    }
}
