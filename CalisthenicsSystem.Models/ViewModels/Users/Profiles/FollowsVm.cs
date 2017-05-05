using System.ComponentModel.DataAnnotations;

namespace CalisthenicsSystem.Models.ViewModels.Users.Profiles
{
    public class FollowsVm
    {
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        public string AvatarPath { get; set; }

        public int Followers { get; set; }
        
        public int Followings { get; set; }
    }
}
