using System.Collections.Generic;
using CalisthenicsSystem.Models.BindingModels.Home;
using CalisthenicsSystem.Models.ViewModels;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<IndexVm> GetArticlesVms();
        void AddMessageFromBm(ContactsBm model, string userName);
    }
}