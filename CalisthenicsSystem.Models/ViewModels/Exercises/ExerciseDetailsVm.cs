using System;

namespace CalisthenicsSystem.Models.ViewModels.Exercises
{
    public class ExerciseDetailsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string VideoId { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
