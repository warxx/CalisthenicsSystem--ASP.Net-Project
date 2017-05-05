using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.ViewModels.Users.Notes
{
    public class CreateNoteVm
    {
        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(4, ErrorMessage = RequiredMinFourSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }
    }
}
