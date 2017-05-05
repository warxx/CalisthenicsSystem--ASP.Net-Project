using System;

namespace CalisthenicsSystem.Models.EntityModels
{
    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public ApplicationUser Author { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
