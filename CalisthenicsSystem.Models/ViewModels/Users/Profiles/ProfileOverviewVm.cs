using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CalisthenicsSystem.Models.Enums;

namespace CalisthenicsSystem.Models.ViewModels.Users.Profiles
{
    public class ProfileOverviewVm
    {
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Дата на раждане")]
        public string BirthDate { get; set; }

        [Display(Name = "Град")]
        public string BirthPlace { get; set; }

        [Display(Name = "Име и фамилия")]
        public string Name { get; set; }

        [Display(Name = "Последно влязъл")]
        public DateTime? LastLogin { get; set; }

        public string UserName { get; set; }

        public string AvatarPath { get; set; }
    }
}
