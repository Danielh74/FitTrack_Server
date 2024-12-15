using DAL.Interfaces;
using FitTrackAPI.DTOs.ExerciseDTOs;
using FitTrackAPI.Mappers;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class ExercisesController(
		IExerciseRepository exerciseRepo,
		IMuscleGroupRepository muscleGroupRepo,
		BlobStorageService blobStorageService
		) : ControllerBase
	{
		[HttpGet("admin")]
		public async Task<IActionResult> GetAll()
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exercises = await exerciseRepo.GetAllAsync();

			if (exercises is null)
			{
				return NoContent();
			}

			return Ok(exercises.Select(e => e.ToDto()).ToList());
		}

		[HttpGet("admin/{id:int}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exercise = await exerciseRepo.GetByIdAsync(id);
			if (exercise is null)
			{
				return NotFound("Exercise was not found");
			}

			return Ok(exercise.ToDto());
		}

		[HttpPost("admin")]
		public async Task<IActionResult> Create([FromForm] CreateExerciseDto exerciseDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var validMuscleGroup = await muscleGroupRepo.GetByNameAsync(exerciseDto.MuscleGroupName);

			if (validMuscleGroup is null)
			{
				return NotFound("A muscle group with this name does not exist.");
			}


			var existingExercise = await exerciseRepo.GetByNameAsync(exerciseDto.Name);
			if (existingExercise is not null)
			{
				return BadRequest("An exercise with this name already exists.");
			}

			string videoUrl = string.Empty;
			if (exerciseDto.VideoFile is not null)
			{
				using (var stream = exerciseDto.VideoFile?.OpenReadStream())
				{
					var blobType = exerciseDto.VideoFile.ContentType.Substring(exerciseDto.VideoFile.ContentType.IndexOf('/') + 1);
					var blobName = $"{exerciseDto.Name.Replace(" ", "_")}.{blobType}";
					videoUrl = await blobStorageService.UploadVideoAsync(stream, blobName, exerciseDto.VideoFile.ContentType);
				}
			}

			var exercise = exerciseDto.ToModelFromCreate(validMuscleGroup.Id, videoUrl);

			await exerciseRepo.CreateAsync(exercise);

			return CreatedAtAction(nameof(GetById), new { Id = exercise.Id }, exercise.ToDto());
		}

		[HttpPut("admin/{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateExerciseRequestDto exerciseDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var validMuscleGroup = await muscleGroupRepo.GetByNameAsync(exerciseDto.MuscleGroupName);
			if (validMuscleGroup is null)
			{
				return NotFound("A muscle group with this name does not exist.");
			}

			string videoUrl = string.Empty;
			if (exerciseDto.VideoFile is not null)
			{
				using (var stream = exerciseDto.VideoFile.OpenReadStream())
				{
					var blobType = exerciseDto.VideoFile.ContentType.Substring(exerciseDto.VideoFile.ContentType.IndexOf('/') + 1);
					var blobName = $"{exerciseDto.Name.Replace(" ", "_")}.{blobType}";
					videoUrl = await blobStorageService.UploadVideoAsync(stream, blobName, exerciseDto.VideoFile.ContentType);
				}
			}

			var updatedExercise = await exerciseRepo.UpdateAsync(id, exerciseDto.ToModelFromUpdate(validMuscleGroup.Id, videoUrl));

			if (updatedExercise is null)
			{
				return BadRequest("Can't update exercise because it does not exist.");
			}

			return Ok(updatedExercise.ToDto());
		}

		[HttpDelete("admin/{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exercise = await exerciseRepo.GetByIdAsync(id);
			if (exercise is null)
			{
				return NotFound("Exercise was not found");
			}

			await exerciseRepo.DeleteAsync(exercise);

			int nameStartIndex = exercise.VideoURL.LastIndexOf('/') + 1;
			string blobName = exercise.VideoURL.Substring(nameStartIndex);

			await blobStorageService.DeleteVideoAsync(blobName);

			return Ok("Exercise deleted successfully");
		}
	}
}
