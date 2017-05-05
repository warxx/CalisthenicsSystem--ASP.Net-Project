using System;
using System.ComponentModel.DataAnnotations;

namespace CalisthenicsSystem.Models.ViewModels.Admin
{
    public class AllMessagesVm
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Дата на изпращане")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Потребител")]
        public string Sender { get; set; }
    }
}
