using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MuscleGroupDTOs
{
	public class UpdateMuscleGroupRequestDto
	{
		[Required]
		[MinLength(2), MaxLength(20)]
		public string Name { get; set; } = string.Empty;
	}
}
