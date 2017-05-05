using System;
using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.BindingModels.Home
{
    public class ContactsBm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(6, ErrorMessage = RequiredMinSixSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Title { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MaxLength(400, ErrorMessage = RequiredMaxFourHundredSymbolsMsg)]
        public string Content { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
