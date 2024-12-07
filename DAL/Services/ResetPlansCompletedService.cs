
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DAL.Services
{
	public class ResetPlansCompletedService(IServiceScopeFactory scopeFactory, ILogger<ResetPlansCompletedService> logger) : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				var now = DateTime.UtcNow;
				var nextSunday = now.Date.AddDays((7 - (int)now.DayOfWeek) % 7);
				var delay = nextSunday - now;

				if (delay.TotalMilliseconds < 0)
				{
					nextSunday = nextSunday.AddDays(7);
					delay = nextSunday - now;
				}

				await Task.Delay(delay, stoppingToken);

				try
				{
					using var scope = scopeFactory.CreateScope();
					var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
					var plans = await dbContext.Plans.ToListAsync(stoppingToken);

					if (plans.Count == 0)
					{
						logger.LogInformation("No plans found to reset.");
					}

					foreach (var plan in plans)
					{
						plan.IsCompleted = false;
					}

					await dbContext.SaveChangesAsync(stoppingToken);
					logger.LogInformation("Plans reset successfully.");
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "Error resetting plans.");
				}

				await Task.Delay(TimeSpan.FromDays(7), stoppingToken);
			}
		}
	}
}
