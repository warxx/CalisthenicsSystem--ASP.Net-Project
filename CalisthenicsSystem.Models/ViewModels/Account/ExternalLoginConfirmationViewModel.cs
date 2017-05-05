using System.ComponentModel.DataAnnotations;

namespace CalisthenicsSystem.Models.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
