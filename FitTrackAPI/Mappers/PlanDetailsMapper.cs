using DAL.Models;
using FitTrackAPI.DTOs.PlanDetailsDTOs;

namespace FitTrackAPI.Mappers
{
	public static class PlanDetailsMapper
	{
		public static PlanDetailsDto ToDto(this PlanDetails model)
		{
			return new PlanDetailsDto
			{
				Id = model.Id,
				OrderInPlan = model.OrderInPlan,
				ExerciseName = model.Exercise.Name,
				VideoURL = model.Exercise.VideoURL,
				Reps = model.Reps,
				Sets = model.Sets,
				CurrentWeight = model.CurrentWeight,
				PreviousWeight = model.PreviousWeight
			};
		}

		public static PlanDetails ToModelFromCreate(this CreatePlanDetailsDto dto)
		{
			return new PlanDetails
			{
				ExerciseId = dto.ExerciseId,
				PlanId = dto.PlanId,
				OrderInPlan = dto.OrderInPlan,
				Sets = dto.Sets,
				Reps = dto.Reps
			};
		}

		public static PlanDetails ToModelFromUpdate(this UpdatePlanDetailsRequestDto dto)
		{
			return new PlanDetails
			{
				OrderInPlan = dto.OrderInPlan,
				Reps = dto.Reps,
				Sets = dto.Sets,
				CurrentWeight = dto.CurrentWeight,
				PreviousWeight = dto.PreviousWeight,
			};
		}
	}
}
