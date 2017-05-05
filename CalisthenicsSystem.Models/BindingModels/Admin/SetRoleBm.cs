using System.Security.AccessControl;

namespace CalisthenicsSystem.Models.BindingModels.Admin
{
    public class SetRoleBm
    {
        public string RoleName { get; set; }

        public string UserName { get; set; }
    }
}
