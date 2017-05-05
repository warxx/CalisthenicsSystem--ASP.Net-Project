using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Articles;
using CalisthenicsSystem.Models.BindingModels.Exercises;
using CalisthenicsSystem.Models.BindingModels.Home;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Models.ViewModels;
using CalisthenicsSystem.Models.ViewModels.Admin;
using CalisthenicsSystem.Models.ViewModels.Articles;
using CalisthenicsSystem.Models.ViewModels.Exercises;
using CalisthenicsSystem.Models.ViewModels.Home;
using CalisthenicsSystem.Models.ViewModels.Users;
using CalisthenicsSystem.Models.ViewModels.Users.Profiles;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalisthenicsSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Article, AllArticlesVm>()
                    .ForMember(vm => vm.Content, cfgExression =>
                            cfgExression.MapFrom(m => m.Content.Substring(0, 400)));
                cfg.CreateMap<Article, ArticleDetailsVm>()
                    .ForMember(vm => vm.AuthorName, cfgExpression =>
                            cfgExpression.MapFrom(m => m.Author.UserName));
                cfg.CreateMap<AddArticleBm, Article>();
                cfg.CreateMap<AddArticleBm, AddArticleVm>();
                cfg.CreateMap<ApplicationUser, ProfileOverviewVm>();
                cfg.CreateMap<ApplicationUser, FollowsVm>()
                    .ForMember(vm => vm.Followers, cfgExpression =>
                            cfgExpression.MapFrom(f => f.Followers.Count))
                    .ForMember(vm => vm.Followings, cfgExpression =>
                            cfgExpression.MapFrom(f => f.Following.Count));
                cfg.CreateMap<ApplicationUser, EditProfileVm>();
                cfg.CreateMap<Exercise, AllExercisesVm>()
                    .ForMember(vm => vm.Content, cfgExression =>
                            cfgExression.MapFrom(m => m.Content.Substring(0, 400)));
                cfg.CreateMap<AddExerciseBm, Exercise>();
                cfg.CreateMap<AddExerciseBm, AddExerciseVm>();
                cfg.CreateMap<Exercise, ExerciseDetailsVm>()
                    .ForMember(vm => vm.AuthorName, cfgExpression =>
                            cfgExpression.MapFrom(m => m.Author.UserName))
                    .ForMember(vm => vm.VideoId, cfgExpression =>
                            cfgExpression.MapFrom(m => m.YoutubeUrl));
                cfg.CreateMap<ApplicationUser, UserVm>();
                cfg.CreateMap<Article, ArticleVm>()
                    .ForMember(vm => vm.AuthorName, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Author.UserName));
                cfg.CreateMap<Exercise, ExerciseVm>()
                    .ForMember(vm => vm.AuthorName, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Author.UserName));
                cfg.CreateMap<IdentityRole, RoleVm>();
                cfg.CreateMap<Article, EditArticleVm>();
                cfg.CreateMap<Article, DeleteArticleVm>()
                    .ForMember(vm => vm.AuthorName, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Author.UserName));
                cfg.CreateMap<Exercise, EditExerciseVm>();
                cfg.CreateMap<Exercise, DeleteExerciseVm>()
                    .ForMember(vm => vm.AuthorName, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Author.UserName));
                cfg.CreateMap<Article, IndexVm>();
                cfg.CreateMap<ApplicationUser, AllUsersVm>()
                    .ForMember(vm => vm.NoteName, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Note.Name));
                cfg.CreateMap<Note, UserNoteVm>()
                    .ForMember(vm => vm.AllReplies, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Topics.Count))
                    .ForMember(vm => vm.AllReplies, cfgExpression =>
                            cfgExpression.MapFrom(u => u.Topics.Sum(x => x.Replies.Count)));
                cfg.CreateMap<ContactsBm, ContactsVm>();
                cfg.CreateMap<Message, MessageVm>()
                    .ForMember(vm => vm.Sender, cfgExpression =>
                            cfgExpression.MapFrom(u => u.User.UserName));
                cfg.CreateMap<Message, AllMessagesVm>()
                    .ForMember(vm => vm.Sender, cfgExpression =>
                            cfgExpression.MapFrom(u => u.User.UserName));
            });
        }
    }
}
