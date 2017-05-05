using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Models.ViewModels.Admin;
using CalisthenicsSystem.Services.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalisthenicsSystem.Services
{
    public class AdminService : Service, IAdminService
    {
        public IEnumerable<UserVm> GetAllUsers()
        {
            var users = this.Context.Users.ToList();

            var vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserVm>>(users);

            return vms;
        }

        public IEnumerable<ArticleVm> GetArticlesVms()
        {
            var articles = this.Context.Articles.ToList();

            var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);

            return vms;
        }

        public IEnumerable<ExerciseVm> GetExercisesVms()
        {
            var exercises = this.Context.Exercises.ToList();

            var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);

            return vms;
        }

        public IEnumerable<AllMessagesVm> GetContactsVms()
        {
            var messages = this.Context.Messages.ToList();

            var vms = Mapper.Map<IEnumerable<Message>, IEnumerable<AllMessagesVm>>(messages);

            return vms;
        }

        public MessageVm GetMessageDetailsVm(int id)
        {
            var message = this.Context.Messages.Find(id);

            if (message == null)
            {
                return null;
            }

            var vm = Mapper.Map<Message, MessageVm>(message);

            return vm;
        }

        public SetRoleVm GetSetRoleVm(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return null;
            }
            
            var vm = new SetRoleVm();

            var roles = this.Context.Roles;
            var rolesVm = Mapper.Map<IEnumerable<IdentityRole>, IEnumerable<RoleVm>>(roles);

            vm.UserName = user.UserName;
            vm.Roles = rolesVm;
            return vm;
        }

        public IEnumerable<ArticleVm> GetSearchedArticlesVms(string word, string category, string type)
        {
            //var articles = this.Context.Articles.Where(n => n.Name.Contains(word)).ToList();
            //var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);

            //return vms;

            if (type == "ascending")
            {
                if (category == "name")
                {
                    var articles = this.Context.Articles.Where(n => n.Name.Contains(word))
                        .OrderBy(x => x.Name).ToList();
                    var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
                    return vms;
                }

                if (category == "publishdate")
                {
                    var articles = this.Context.Articles.Where(n => n.Name.Contains(word))
                        .OrderBy(x => x.PublishDate).ToList();
                    var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
                    return vms;
                }
                else
                {
                    var articles = this.Context.Articles.Where(n => n.Name.Contains(word))
                        .OrderBy(x => x.Author.Name).ToList();
                    var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
                    return vms;
                }
            }

            if (category == "name")
            {
                var articles = this.Context.Articles.Where(n => n.Name.Contains(word))
                    .OrderByDescending(x => x.Name).ToList();
                var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
                return vms;
            }

            if (category == "publishdate")
            {
                var articles = this.Context.Articles.Where(n => n.Name.Contains(word))
                    .OrderByDescending(x => x.PublishDate).ToList();
                var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
                return vms;
            }

            else
            {
                var articles = this.Context.Articles.Where(n => n.Name.Contains(word))
                    .OrderByDescending(x => x.Author.Name).ToList();
                var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVm>>(articles);
                return vms;
            }
        }

        public IEnumerable<ExerciseVm> GetSearchedExercisesVms(string word, string category, string type)
        {

            if (type == "ascending")
            {
                if (category == "name")
                {
                    var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word))
                        .OrderBy(x => x.Name).ToList();
                    var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);
                    return vms;
                }

                if (category == "publishdate")
                {
                    var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word))
                        .OrderBy(x => x.PublishDate).ToList();
                    var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);
                    return vms;
                }
                else
                {
                    var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word))
                        .OrderBy(x => x.Author.Name).ToList();
                    var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);
                    return vms;
                }
            }

            if (category == "name")
            {
                var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word))
                    .OrderByDescending(x => x.Name).ToList();
                var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);
                return vms;
            }

            if (category == "publishdate")
            {
                var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word))
                    .OrderByDescending(x => x.PublishDate).ToList();
                var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);
                return vms;
            }

            else
            {
                var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word))
                    .OrderByDescending(x => x.Author.Name).ToList();
                var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseVm>>(exercises);
                return vms;
            }
        }

        public IEnumerable<UserVm> GetSearchedUsersVms(string word, string category, string type)
        {

            if (type == "ascending")
            {
                if (category == "username")
                {
                    var users = this.Context.Users.Where(u => u.UserName.Contains(word))
                        .OrderBy(x => x.UserName).ToList();
                    var vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserVm>>(users);
                    return vms;
                }
                else
                {
                    var users = this.Context.Users.Where(u => u.UserName.Contains(word))
                        .OrderBy(x => x.Email).ToList();
                    var vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserVm>>(users);
                    return vms;
                }
            }

            if (category == "username")
            {
                var users = this.Context.Users.Where(u => u.UserName.Contains(word))
                    .OrderByDescending(x => x.UserName).ToList();
                var vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserVm>>(users);
                return vms;
            }
            else
            {
                var users = this.Context.Users.Where(u => u.UserName.Contains(word))
                    .OrderByDescending(x => x.Email).ToList();
                var vms = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserVm>>(users);
                return vms;
            }
        }
    }
}
