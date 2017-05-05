using System;

namespace CalisthenicsSystem.Models.ViewModels.Exercises
{
    public class DeleteExerciseVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorName { get; set; }
    }
}
