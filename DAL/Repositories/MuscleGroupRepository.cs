using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class MuscleGroupRepository(AppDbContext context) : IMuscleGroupRepository
	{
		public async Task<MuscleGroup> CreateAsync(MuscleGroup muscleGroup)
		{
			await context.AddAsync(muscleGroup);
			await context.SaveChangesAsync();

			return muscleGroup;
		}

		public async Task<MuscleGroup?> DeleteAsync(MuscleGroup muscleGroup)
		{
			context.MuscleGroups.Remove(muscleGroup);
			await context.SaveChangesAsync();

			return muscleGroup;
		}

		public async Task<List<MuscleGroup>> GetAllAsync()
		{
			var muscleGroups = await context.MuscleGroups.Include(m => m.Exercises).ToListAsync();
			if (muscleGroups.Count == 0) {
				return null;
			}

			return  muscleGroups;
		}

		public async Task<MuscleGroup?> GetByIdAsync(int id)
		{
			var muscleGroup = await context.MuscleGroups
				.Include(m => m.Exercises)
				.FirstOrDefaultAsync(m => m.Id == id);

			return muscleGroup;
		}

		public async Task<MuscleGroup?> GetByNameAsync(string name)
		{
			var muscleGroup = await context.MuscleGroups.FirstOrDefaultAsync(m => m.Name == name);

			return muscleGroup;
		}

		public async Task<MuscleGroup?> UpdateAsync(int id, MuscleGroup updatedMuscleGroup)
		{
			var currentMuscleGroup = await context.MuscleGroups.FindAsync(id);
			if (currentMuscleGroup is null)
			{
				return null;
			}

			if(await GetByNameAsync(updatedMuscleGroup.Name) is not null)
			{
				return null;
			}

			currentMuscleGroup.Name = updatedMuscleGroup.Name;

			await context.SaveChangesAsync();

			return currentMuscleGroup;
		}
	}
}
