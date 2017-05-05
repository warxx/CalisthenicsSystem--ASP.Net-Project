using System;
using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Потребителско име")]
        [Required]
        [RegularExpression("^[a-zA-Z]{1}[a-zA-Z0-9]{3,30}$", ErrorMessage = UsernameValidationMessage)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме ?")]
        public bool RememberMe { get; set; }
    }
}
