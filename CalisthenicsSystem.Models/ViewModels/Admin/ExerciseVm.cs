using System;

namespace CalisthenicsSystem.Models.ViewModels.Admin
{
    public class ExerciseVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorName { get; set; }
    }
}
