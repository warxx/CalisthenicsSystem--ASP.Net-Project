using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Home;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Models.ViewModels;
using CalisthenicsSystem.Services.Interfaces;

namespace CalisthenicsSystem.Services
{
    public class HomeService : Service, IHomeService
    {
        public IEnumerable<IndexVm> GetArticlesVms()
        {

            var articles = this.Context.Articles.OrderByDescending(x => x.PublishDate).Take(3);
            if (articles.Count() < 3)
            {
                return null;
            }

            var vms = Mapper.Map<IEnumerable<Article>, IEnumerable<IndexVm>>(articles);

            return vms;
        }

        public void AddMessageFromBm(ContactsBm model, string userName)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            var message = new Message()
            {
                Title = model.Title,
                Content = model.Content,
                Email = model.Email,
                PublishDate = DateTime.Now,
                User = user
            };
            
            this.Context.Messages.Add(message);
            this.Context.SaveChanges();
        }
    }
}
