using System;
using System.ComponentModel.DataAnnotations;
using CalisthenicsSystem.Models.Enums;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.BindingModels.Users
{
    public class EditProfileBm
    {
        public string UserName { get; set; }

        [MinLength(4, ErrorMessage = RequiredMinFourSymbolsMsg)]
        [MaxLength(40, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public DateTime? BirthDate { get; set; }
        
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string BirthPlace { get; set; }

        public string AvatarPath { get; set; }

        public Gender Gender { get; set; }
    }
}
