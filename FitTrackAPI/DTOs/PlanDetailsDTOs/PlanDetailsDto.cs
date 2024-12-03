using DAL.Models;

namespace FitTrackAPI.DTOs.PlanDetailsDTOs
{
	public class PlanDetailsDto
	{
        public int Id { get; set; }
        public int? OrderInPlan { get; set; }
		public string ExerciseName { get; set;} = string.Empty;
		public int? Reps { get; set; }
		public int? Sets { get; set; }
		public double? CurrentWeight { get; set; }
		public double? PreviousWeight { get; set; }
	}
}
