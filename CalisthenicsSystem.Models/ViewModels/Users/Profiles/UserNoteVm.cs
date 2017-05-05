using System;
using System.ComponentModel.DataAnnotations;

namespace CalisthenicsSystem.Models.ViewModels.Users.Profiles
{
    public class UserNoteVm
    {
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Преглеждания")]
        public int Views { get; set; }

        [Display(Name = "Брой теми")]
        public int AllTopics { get; set; }

        [Display(Name = "Брой отговори")]
        public int AllReplies { get; set; }

        [Display(Name = "Дата на създаване")]
        public DateTime DateCreated { get; set; }
    }
}
