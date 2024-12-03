using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MealDTOs
{
	public class UpdateMealRequestDto
	{
		[Range(1, 20)]
		public int? ProteinPoints { get; set; }

		[Range(1, 20)]
		public int? CarbsPoints { get; set; }

		[Range(1, 20)]
		public int? FatsPoints { get; set; }
        public bool IsCompleted { get; set; }
    }
}
