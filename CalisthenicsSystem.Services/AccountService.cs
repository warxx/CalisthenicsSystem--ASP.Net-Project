using System;
using System.Data.Entity;
using System.Linq;
using CalisthenicsSystem.Models.ViewModels.Account;
using CalisthenicsSystem.Services.Interfaces;

namespace CalisthenicsSystem.Services
{

    public class AccountService : Service, IAccountService
    {
        public void GetLastLogin(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName == userName);
            user.LastLogin = DateTime.Now;
            
            this.Context.Entry(user).State = EntityState.Modified;
            this.Context.SaveChanges();
        }
    }
}
