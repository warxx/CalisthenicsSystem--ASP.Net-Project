using System;
using System.ComponentModel.DataAnnotations;
using CalisthenicsSystem.Models.Enums;
using static CalisthenicsSystem.Models.Constants.ValidationRegularExpressions;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.EntityModels
{
    public class Exercise
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

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(YouTubeUrlRegex, ErrorMessage = YouTubeUrlValidationMsg)]
        public string YoutubeUrl { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public MuscleGroups MuscleGroup { get; set; }
    }
}
