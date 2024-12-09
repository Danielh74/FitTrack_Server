namespace FitTrackAPI.DTOs.ExerciseDTOs
{
	public class ExerciseDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string MuscleGroupName { get; set; } = string.Empty;
		public string VideoURL { get; set; } = string.Empty;
	}
}
