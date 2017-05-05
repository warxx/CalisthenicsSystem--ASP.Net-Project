using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalisthenicsSystem.Models.ViewModels.Admin
{
    public class SetRoleVm
    {
        public string UserName { get; set; }

        [Display(Name = "Роли")]
        public IEnumerable<RoleVm> Roles { get; set; }
    }
}
