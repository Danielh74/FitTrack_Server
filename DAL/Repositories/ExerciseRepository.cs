using DAL.Data;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DAL.Repositories
{
	public class ExerciseRepository(AppDbContext context) : IExerciseRepository
	{
		public async Task<Exercise> CreateAsync(Exercise exerciseModel)
		{
			await context.Exercises.AddAsync(exerciseModel);
			await context.SaveChangesAsync();

			return exerciseModel;
		}

		public async Task<Exercise?> DeleteAsync(Exercise exerciseModel)
		{
			context.Exercises.Remove(exerciseModel);
			await context.SaveChangesAsync();

			return exerciseModel;
		}

		public async Task<List<Exercise>> GetAllAsync()
		{
			var exercises = await context.Exercises.Include(e => e.MuscleGroup).ToListAsync();
			if(exercises.Count == 0)
			{
				return null;
			}

			return  exercises;
		}

		public async Task<Exercise?> GetByIdAsync(int id)
		{
			var exercise = await context.Exercises
				.Include(e => e.MuscleGroup)
				.FirstOrDefaultAsync(e => e.Id == id);

			return exercise;
		}

		public async Task<Exercise?> GetByNameAsync(string name)
		{
			var exercise = await context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
			if (exercise is null)
			{
				return null;
			}
			return exercise;
		}

		public async Task<Exercise?> UpdateAsync(int id, Exercise updatedExercise)
		{
			var currentExercise = await context.Exercises.FindAsync(id);
			if (currentExercise is null)
			{
				return null;
			}

			currentExercise.Name = updatedExercise.Name;
			currentExercise.MuscleGroupId = updatedExercise.MuscleGroupId;
			if(!string.IsNullOrEmpty(updatedExercise.VideoURL))
			{
				currentExercise.VideoURL = updatedExercise.VideoURL;
			}

			await context.SaveChangesAsync();

			return currentExercise;
		}
	}
}
