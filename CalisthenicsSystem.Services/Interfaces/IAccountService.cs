using CalisthenicsSystem.Models.ViewModels.Account;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface IAccountService
    {
        void GetLastLogin(string userName);
    }
}