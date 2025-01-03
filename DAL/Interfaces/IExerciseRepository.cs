﻿using DAL.Models;

namespace DAL.Interfaces
{
	public interface IExerciseRepository
	{
		Task<List<Exercise>> GetAllAsync();
		Task<Exercise?> GetByIdAsync(int id);
		Task<Exercise?> GetByNameAsync(string name);
		Task<Exercise> CreateAsync(Exercise exerciseModel);
		Task<Exercise?> UpdateAsync(int id, Exercise exerciseModel);
		Task<Exercise?> DeleteAsync(Exercise exerciseModel);
	}
}
