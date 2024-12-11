using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.HealthDeclarationDTOs;
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
	public class HealthDeclarationsController(IHealthDeclarationRepository repo, UserManager<AppUser> userManager) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var healthDecs = await repo.GetAllAsync();
			if(healthDecs is null)
			{
				return NoContent();
			}

			return Ok(healthDecs.Select(h=> h.ToDto()));
		}

		[HttpGet("admin/user/{userId}")]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> GetByUserId(int userId)
		{
			var healthDec = await repo.GetByUserIdAsync(userId);

			if(healthDec is null)
			{
				return NotFound("User does not have health declaration");
			}

			return Ok(healthDec.ToDto());
		}

		[HttpGet("admin/{Id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetById(int id)
		{
			var healthDec = await repo.GetByIdAsync(id);

			if (healthDec is null)
			{
				return NotFound("Health declaration does not exist");
			}

			return Ok(healthDec.ToDto());
		}

		[HttpPost("admin")]
		public async Task<IActionResult> Create([FromBody]CreateHealthDeclarationDto createDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			if (userEmail is null)
			{
				return NotFound("Email does not exist in database.");
			}

			var user = await userManager.FindByEmailAsync(userEmail);
			if (user is null)
			{
				return NotFound("User not found for the given email.");
			}

			if (user.HealthDeclaration is not null)
			{
				return BadRequest("User already has a health declaration");
			}

			var healthDec = createDto.ToModelFromCreate(user.Id);

			var result = await repo.CreateAsync(healthDec);

			return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToDto());
		}

		[HttpDelete("admin/{id}")]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var healthDec = await repo.GetByIdAsync(id);
			if (healthDec is null)
			{
				return NotFound("Health declaration was not found.");
			}

			await repo.DeleteAsync(healthDec);

			return Ok("Item deleted successfully");
		}
	}
}
