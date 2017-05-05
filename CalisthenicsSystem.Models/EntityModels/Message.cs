using System;
using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.EntityModels
{
    public class Message
    {
        public int Id { get; set; }

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

        [Required]
        public DateTime PublishDate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
