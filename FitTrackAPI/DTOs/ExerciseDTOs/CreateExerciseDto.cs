using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.ExerciseDTOs
{
	public class CreateExerciseDto
	{
		[Required]
		[MinLength(2), MaxLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[MinLength(2), MaxLength(20)]
		public string MuscleGroupName { get; set; } = string.Empty;
	}
}
