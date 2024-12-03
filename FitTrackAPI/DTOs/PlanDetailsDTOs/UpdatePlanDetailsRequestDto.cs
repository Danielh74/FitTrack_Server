using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDetailsDTOs
{
	public class UpdatePlanDetailsRequestDto
	{
		[Range(1, int.MaxValue)]
		public int? OrderInPlan { get; set; }

		[Range(1, int.MaxValue)]
		public int? Reps { get; set; }

		[Range(1, int.MaxValue)]
		public int? Sets { get; set; }

		[Range(1, double.MaxValue)]
		public double? CurrentWeight { get; set; }

		[Range(1, double.MaxValue)]
		public double? PreviousWeight { get; set; }
	}
}
