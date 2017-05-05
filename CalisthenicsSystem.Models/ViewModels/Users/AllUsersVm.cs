using System.ComponentModel.DataAnnotations;
using CalisthenicsSystem.Models.Enums;

namespace CalisthenicsSystem.Models.ViewModels.Users
{
    public class AllUsersVm
    {
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Display(Name = "Дневник")]
        public string NoteName { get; set; }

       // [Display(Name = "")]
        public string AvatarPath { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Град")]
        public string BirthPlace { get; set; }
    }
}
