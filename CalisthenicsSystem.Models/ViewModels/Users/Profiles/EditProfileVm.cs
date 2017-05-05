using System;
using System.ComponentModel.DataAnnotations;
using CalisthenicsSystem.Models.Enums;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.ViewModels.Users.Profiles
{
    public class EditProfileVm
    {
        public string UserName { get; set; }

        [Display(Name = "Име и фамилия")]
        [MinLength(4, ErrorMessage = RequiredMinFourSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        [Display(Name = "Дата на раждане")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Град")]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string BirthPlace { get; set; }

        [Display(Name = "Аватар")]
        public string AvatarPath { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
    }
}
