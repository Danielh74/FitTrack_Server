using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MealDTOs
{
	public class UpdateMealCompleteRequestDto
	{
		[Required]
		public int Id { get; set; }
		[Required]
        public bool IsCompleted { get; set; }
    }
}
