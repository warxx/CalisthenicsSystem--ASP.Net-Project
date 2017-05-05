using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CalisthenicsSystem.Models.Constants.ValidationMessages;
using System.Security.Claims;
using System.Threading.Tasks;
using CalisthenicsSystem.Models.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CalisthenicsSystem.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Followers = new HashSet<ApplicationUser>();
            this.Following = new HashSet<ApplicationUser>();
        }

        public int ProfileViews { get; set; }

        public Gender Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [MaxLength(50, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string BirthPlace { get; set; }

        [MinLength(4, ErrorMessage = RequiredMinFourSymbolsMsg)]
        [MaxLength(40, ErrorMessage = RequiredMaxFiftySymbolsMsg)]
        public string Name { get; set; }

        public string AvatarPath { get; set; }

        public DateTime? LastLogin { get; set; }

        public virtual Note Note { get; set; }

        public virtual ICollection<ApplicationUser> Followers { get; set; }

        public virtual ICollection<ApplicationUser> Following { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
