using CalisthenicsSystem.Models.BindingModels.Users.Notes;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface INoteService
    {
        bool IsUserHasNote(string userName);
        void CreateNotFromBm(CreateNoteBm model, string userName);
    }
}