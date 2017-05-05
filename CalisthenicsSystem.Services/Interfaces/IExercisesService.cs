using System.Collections.Generic;
using CalisthenicsSystem.Models.BindingModels.Exercises;
using CalisthenicsSystem.Models.ViewModels.Exercises;

namespace CalisthenicsSystem.Services.Interfaces
{
    public interface IExercisesService
    {
        IEnumerable<AllExercisesVm> GetAllExercises(string type);
        void AddExerciseFromBm(AddExerciseBm model, string userId, string fileName);
        ExerciseDetailsVm GetExerciseDetailsVm(int? exerciseId);
        EditExerciseVm GetEditExerciseVm(int exerciseId);
        bool IsExerciseExist(int exerciseId);
        void EditExerciseFromBm(EditExerciseBm model, string fileName);
        DeleteExerciseVm GetDeleteExerciseVm(int exerciseId);
        void DeleteExercise(int exerciseId);
        IEnumerable<AllExercisesVm> GetSearchedExercisesVms(string word);
    }
}