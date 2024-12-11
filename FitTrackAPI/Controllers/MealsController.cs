using DAL.Interfaces;
using FitTrackAPI.DTOs.MealDTOs;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MealsController(IMealRepository repo) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var mealsList = await repo.GetAllAsync();
			if (mealsList is null)
			{
				return NoContent();
			}

			return Ok(mealsList.Select(md => md.ToListDto()));
		}

		[HttpGet("admin/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var meal = await repo.GetByIdAsync(id);
			if (meal is null)
			{
				return NotFound("Meal was not found.");
			}

			return Ok(meal.ToDto());
		}

		[HttpPost("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create([FromBody] CreateMealDto createDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var meal = await repo.CreateAsync(createDto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new { Id = meal.Id }, meal.ToDto());
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMealRequestDto updateDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (!User.IsInRole("Admin") && (updateDto.ProteinPoints.HasValue || updateDto.CarbsPoints.HasValue || updateDto.FatsPoints.HasValue))
			{
				return Unauthorized("User is not authorized to change these fields");
			}

			var meal = await repo.UpdateAsync(id, updateDto.ToModelFromUpdate());
			if (meal is null)
			{
				return NotFound("Meal was not found.");
			}

			return Ok(meal.ToDto());
		}

		[HttpDelete("admin/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			var meal = await repo.GetByIdAsync(id);
			if (meal is null)
			{
				return NotFound("Meal was not found.");
			}

			await repo.DeleteAsync(meal);

			return Ok("Meal deleted successfully");
		}
	}
}
