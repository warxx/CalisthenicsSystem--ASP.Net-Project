using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalisthenicsSystem.Models.ViewModels.Admin
{
    public class UserVm
    {
        public string Id { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Display(Name = "Имейл адрес")]
        public string Email { get; set; }

        public List<string> Roles { get; set; }
    }
}
