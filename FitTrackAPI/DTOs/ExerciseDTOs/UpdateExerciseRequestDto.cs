using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.ExerciseDTOs
{
	public class UpdateExerciseRequestDto
	{
		[Required]
		[MinLength(2), MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[MinLength(2), MaxLength(20)]
		public string MuscleGroupName { get; set; } = string.Empty;

		public IFormFile? VideoFile { get; set; }
	}
}
