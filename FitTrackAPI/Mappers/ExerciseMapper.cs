using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.ExerciseDTOs;

namespace FitTrackAPI.Mappers
{
	public static class ExerciseMapper
	{
		public static ExerciseDto ToDto(this Exercise exerciseModel)
		{
			return new ExerciseDto
			{
				Id = exerciseModel.Id,
				Name = exerciseModel.Name,
				MuscleGroupName = exerciseModel.MuscleGroup.Name,
				VideoURL = exerciseModel.VideoURL
			};
		}

		public static Exercise ToModelFromCreate(this CreateExerciseDto exerciseDto, int muscleGroupId, string videoUrl)
		{
			return new Exercise
			{
				Name = exerciseDto.Name,
				MuscleGroupId = muscleGroupId,
				VideoURL = videoUrl
			};
		}

		public static Exercise  ToModelFromUpdate(this UpdateExerciseRequestDto exerciseDto, int muscleGroupId, string videoUrl)
		{

			return new Exercise
			{
				Name = exerciseDto.Name,
				MuscleGroupId = muscleGroupId,
				VideoURL = videoUrl
			};
		}
	}
}
