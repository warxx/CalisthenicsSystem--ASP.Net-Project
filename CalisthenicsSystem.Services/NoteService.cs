using System;
using System.Linq;
using CalisthenicsSystem.Models.BindingModels.Users.Notes;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Services.Interfaces;

namespace CalisthenicsSystem.Services
{
    public class NoteService : Service, INoteService
    {

        public bool IsUserHasNote(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user.Note != null)
            {
                return true;
            }

            return false;
        }

        public void CreateNotFromBm(CreateNoteBm model, string userName)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName == userName);

            var note = new Note
            {
                Name = model.Name,
                DateCreated = DateTime.Now,
                User = user
            };

            this.Context.Notes.Add(note);
            this.Context.SaveChanges();
        }
    }
}
