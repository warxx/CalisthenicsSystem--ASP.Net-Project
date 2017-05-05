using System;

namespace CalisthenicsSystem.Models.ViewModels.Admin
{
    public class ArticleVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorName { get; set; }
    }
}
