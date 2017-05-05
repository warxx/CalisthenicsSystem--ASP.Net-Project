using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;
using static CalisthenicsSystem.Models.Constants.ValidationRegularExpressions;

namespace CalisthenicsSystem.Models.ViewModels.Exercises
{
    public class EditExerciseVm
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(6, ErrorMessage = RequiredMinSixSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(400, ErrorMessage = RequiredMinFourHundredSymbolsMsg)]
        public string Content { get; set; }

        //[Display(Name = "Линк към снимка")]
        //[Required(ErrorMessage = RequiredValidationMessage)]
        //[RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlValidationMsg)]
        //public string ImageUrl { get; set; }

        [Display(Name = "YouTube Видео")]
        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(YouTubeUrlRegex, ErrorMessage = YouTubeUrlValidationMsg)]
        public string YoutubeUrl { get; set; }
    }
}
