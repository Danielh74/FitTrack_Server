namespace FitTrackAPI.DTOs.MuscleGroupDTOs
{
	public class MuscleGroupDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public List<string> Exercises { get; set; } = [];
	}
}
