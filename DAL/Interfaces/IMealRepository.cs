using DAL.Models;

namespace DAL.Interfaces
{
	public interface IMealRepository
	{
		Task<List<Meal>> GetAllAsync();
		Task<Meal?> GetByIdAsync(int id);
		Task<Meal> CreateAsync(Meal meal);
		Task<Meal?> UpdateAsync(int id, Meal meal);
		Task<Meal?> DeleteAsync(Meal meal);
	}
}
