using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DAL.Services
{
	public class ResetMealsCompletedService(IServiceScopeFactory scopeFactory, ILogger<ResetPlansCompletedService> logger) : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				var now = DateTime.UtcNow;
				var tomorrow = now.Date.AddDays(1);

				var delay = tomorrow - now;

				if (delay.TotalMilliseconds < 0)
				{
					tomorrow = tomorrow.AddDays(1);
					delay = tomorrow - now;
				}

				await Task.Delay(delay, stoppingToken);

				try
				{
					using var scope = scopeFactory.CreateScope();
					var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
					var meals = await dbContext.Meals.ToListAsync(stoppingToken);

					if (meals.Count == 0)
					{
						logger.LogInformation("No meals found to reset.");
					}

					foreach (var meal in meals)
					{
						meal.IsCompleted = false;
					}

					await dbContext.SaveChangesAsync(stoppingToken);
					logger.LogInformation("meals reset successfully.");
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "Error resetting meals.");
				}

				await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
			}
		}
	}
}
