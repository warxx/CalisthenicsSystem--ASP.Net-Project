using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;

namespace CalisthenicsSystem.Models.EntityModels
{
    public class Note
    {
        public Note()
        {
            this.Topics = new HashSet<Topic>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [MinLength(4, ErrorMessage = RequiredMinFourSymbolsMsg)]
        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
