using System;
using System.ComponentModel.DataAnnotations;
using CalisthenicsSystem.Models.Constants;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;
using static CalisthenicsSystem.Models.Constants.ValidationRegularExpressions;

namespace CalisthenicsSystem.Models.EntityModels
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(6, ErrorMessage = RequiredMinSixSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(400, ErrorMessage = RequiredMinFourHundredSymbolsMsg)]
        public string Content { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlValidationMsg)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        public DateTime PublishDate { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
