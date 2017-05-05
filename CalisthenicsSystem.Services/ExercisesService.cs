using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CalisthenicsSystem.Models.BindingModels.Exercises;
using CalisthenicsSystem.Models.EntityModels;
using CalisthenicsSystem.Models.Enums;
using CalisthenicsSystem.Models.ViewModels.Exercises;
using CalisthenicsSystem.Services.Interfaces;

namespace CalisthenicsSystem.Services
{
    public class ExercisesService : Service, IExercisesService
    {
        public IEnumerable<AllExercisesVm> GetAllExercises(string type)
        {
            string exercisesType = type.ToLower();

            switch (exercisesType)
            {
                case "arms":
                    var armsExercises = this.Context.Exercises.Where(m=>m.MuscleGroup == MuscleGroups.Arms);
                    var armsVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(armsExercises);
                    return armsVms;
                case "back":
                    var backExercises = this.Context.Exercises.Where(m => m.MuscleGroup == MuscleGroups.Back);
                    var backVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(backExercises);
                    return backVms;
                case "chest":
                    var chestExercises = this.Context.Exercises.Where(m => m.MuscleGroup == MuscleGroups.Chest);
                    var chestVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(chestExercises);
                    return chestVms;
                case "deltoids":
                    var deltoidsExercises = this.Context.Exercises.Where(m => m.MuscleGroup == MuscleGroups.Deltoids);
                    var deltoidsVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(deltoidsExercises);
                    return deltoidsVms;
                case "abs":
                    var absExercises = this.Context.Exercises.Where(m => m.MuscleGroup == MuscleGroups.Abs);
                    var absVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(absExercises);
                    return absVms;
                case "legs":
                    var legsExercises = this.Context.Exercises.Where(m => m.MuscleGroup == MuscleGroups.Legs);
                    var legsVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(legsExercises);
                    return legsVms;
                case "all":
                    var allExercises = this.Context.Exercises;
                    var allVms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(allExercises);
                    return allVms;
                default:
                    return null;
            }
        }

        public void AddExerciseFromBm(AddExerciseBm model, string userId, string fileName)
        {
            var author = this.Context.Users.Find(userId);

            var exercise = Mapper.Map<AddExerciseBm, Exercise>(model);
            exercise.PublishDate = DateTime.Now;
            exercise.Author = author;
            exercise.ImageUrl = fileName;

            this.Context.Exercises.Add(exercise);
            this.Context.SaveChanges();
        }

        public ExerciseDetailsVm GetExerciseDetailsVm(int? exerciseId)
        {
            var exercise = this.Context.Exercises.Find(exerciseId);

            if (exercise == null)
            {
                return null;
            }

            var viewModel = Mapper.Map<Exercise, ExerciseDetailsVm>(exercise);

            return viewModel;
        }

        public EditExerciseVm GetEditExerciseVm(int exerciseId)
        {
            var exercise = this.Context.Exercises.Find(exerciseId);

            if (exercise == null)
            {
                return null;
            }

            var vm = Mapper.Map<Exercise, EditExerciseVm>(exercise);

            return vm;
        }

        public bool IsExerciseExist(int exerciseId)
        {
            var exercise = this.Context.Exercises.Find(exerciseId);

            if (exercise == null)
            {
                return false;
            }

            return true;
        }

        public void EditExerciseFromBm(EditExerciseBm model, string fileName)
        {
            var exercise = this.Context.Exercises.Find(model.Id);

            exercise.Name = model.Name;
            exercise.Content = model.Content;
            exercise.YoutubeUrl = model.YoutubeUrl;

            if (fileName != null)
            {
               exercise.ImageUrl = fileName;
            }

            this.Context.SaveChanges();
        }

        public DeleteExerciseVm GetDeleteExerciseVm(int exerciseId)
        {
            var exercise = this.Context.Exercises.Find(exerciseId);

            if (exercise == null)
            {
                return null;
            }

            var vm = Mapper.Map<Exercise, DeleteExerciseVm>(exercise);

            return vm;
        }

        public void DeleteExercise(int exerciseId)
        {
            var exercise = this.Context.Exercises.Find(exerciseId);
            this.Context.Exercises.Remove(exercise);
            this.Context.SaveChanges();
        }

        public IEnumerable<AllExercisesVm> GetSearchedExercisesVms(string word)
        {
            var exercises = this.Context.Exercises.Where(n => n.Name.Contains(word));
            var vms = Mapper.Map<IEnumerable<Exercise>, IEnumerable<AllExercisesVm>>(exercises);

            return vms;
        }
    }
}
