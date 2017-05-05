using System.ComponentModel.DataAnnotations;
using CalisthenicsSystem.Models.Enums;
using static CalisthenicsSystem.Models.Constants.ValidationRegularExpressions;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.BindingModels.Exercises
{
    public class AddExerciseBm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(6, ErrorMessage = RequiredMinSixSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(400, ErrorMessage = RequiredMinFourHundredSymbolsMsg)]
        public string Content { get; set; }

        //[Required(ErrorMessage = RequiredValidationMessage)]
        //[RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlValidationMsg)]
        // public HttpPostedFileBaseModelBinder ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(YouTubeUrlRegex, ErrorMessage = YouTubeUrlValidationMsg)]
        public string YoutubeUrl { get; set; }

        public MuscleGroups MuscleGroup { get; set; }
    }
}
