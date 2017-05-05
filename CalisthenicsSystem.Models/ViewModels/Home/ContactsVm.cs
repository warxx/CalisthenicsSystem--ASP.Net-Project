using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.ViewModels.Home
{
    public class ContactsVm
    {
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(6, ErrorMessage = RequiredMinSixSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = RequiredValidationMessage)]       
        [MaxLength(400, ErrorMessage = RequiredMaxFourHundredSymbolsMsg)]
        public string Content { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [EmailAddress]
        [Display(Name = "Ел.поща")]
        public string Email { get; set; }
    }
}
