using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "Потребителско име")]
        [Required]
        [RegularExpression("^[a-zA-Z]{1}[a-zA-Z0-9]{3,30}$", ErrorMessage = UsernameValidationMessage)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Ел.поща")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0}та трябва да бъде поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете паролата")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
