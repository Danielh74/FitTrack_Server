using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.PlanDTOs;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PlansController(IPlanRepository repo, UserManager<AppUser> userManager) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var plans = await repo.GetAllAsync();
			if (plans is null)
			{
				return NoContent();
			}

			return Ok(plans.Select(p => p.ToListDto()));

		}

		[HttpGet("admin/{id:int}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetById(int id)
		{
			var plan = await repo.GetByIdAsync(id);
			if (plan is null)
			{
				return BadRequest("Plan does not exist");
			}

			return Ok(plan.ToPlanDto());

		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetByUserId([FromRoute] int userId)
		{
			var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
			if (user == null)
			{
				return BadRequest("Invalid user Id");
			}

			var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

			if (!User.IsInRole("Admin") && currentUserId != userId)
			{
				return Forbid();
			}

			var plans = await repo.GetByUserIdAsync(userId);
			if (plans == null)
			{
				return NotFound("No plans found for this user.");
			}

			return Ok(plans.Select(p => p.ToPlanDto()).ToList());
		}

		[HttpPost("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create([FromBody] CreatePlanDto planDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var validUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == planDto.UserId);
			if (validUser is null)
			{
				return NotFound($"User with Id {planDto.UserId} was not found.");
			}

			var plan = await repo.CreateAsync(planDto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new { id = plan.Id }, new { Plan = plan.ToPlanDto() ,Message = "Plan was created successfully"});
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlanRequestDto planDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var plan = await repo.UpdateAsync(id, planDto.ToModelFromUpdate());
			if (plan is null)
			{
				return NotFound("Plan was not found");
			}

			return Ok(plan.ToPlanDto());
		}

		[HttpDelete("admin/{id:int}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var plan = await repo.GetByIdAsync(id);
			if (plan is null)
			{
				return NotFound("Plan was not found");
			}

			await repo.DeleteAsync(plan);

			return Ok("Plan deleted successfully");
		}
	}
}
