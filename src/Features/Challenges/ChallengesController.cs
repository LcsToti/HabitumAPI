using HabitumAPI.Exceptions;
using HabitumAPI.Features.Challenges.DTOs.Input;
using HabitumAPI.Features.Challenges.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabitumAPI.Features.Challenges;

[Authorize]
[Route("[controller]")]
[ApiController]
public class ChallengesController(IChallengeService _challengeCrudService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateChallenge([FromBody] CreateChallengeRequestDTO inputDto)
    {
        var response = await _challengeCrudService.CreateChallengeAsync(inputDto);

        return CreatedAtAction(nameof(GetChallengeById), new { id = response.Id }, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChallenges()
    {
        var response = await _challengeCrudService.GetChallengesAsync();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChallengeById(int id)
    {
        try
        {
            var response = await _challengeCrudService.GetChallengeAsync(id);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateChallenge(int id, [FromBody] UpdateChallengeRequestDTO inputDto)
    {
        try
        {
            var response = await _challengeCrudService.UpdateChallengeAsync(inputDto, id);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChallenge(int id)
    {
        try
        {
            await _challengeCrudService.DeleteChallengeAsync(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
