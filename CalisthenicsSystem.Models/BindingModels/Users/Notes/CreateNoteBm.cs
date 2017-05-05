using System;
using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.BindingModels.Users.Notes
{
    public class CreateNoteBm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(4, ErrorMessage = RequiredMinFourSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
