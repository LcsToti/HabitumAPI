using HabitumAPI.Exceptions;
using HabitumAPI.Features.Items.Habits.Dtos.Input;
using HabitumAPI.Features.Items.Habits.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitumAPI.Features.Items.Habits;

[Route("Me/[controller]")]
[ApiController]
public class HabitsController(IHabitCrudService habitCrudService, IHabitLogicService habitLogicService) : ControllerBase
{
    private readonly IHabitCrudService _habitCrudService = habitCrudService;
    private readonly IHabitLogicService _habitLogicService = habitLogicService;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var response = await _habitCrudService.GetAllUserHabits(userId);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("Pending")]
    public async Task<IActionResult> GetPending()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var response = await _habitCrudService.GetPendingHabitsByUser(userId);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("Done")]
    public async Task<IActionResult> GetDone()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var response = await _habitCrudService.GetDoneHabitsByUser(userId);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            var response = await _habitCrudService.GetUserHabitById(id, userId);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHabitRequestDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        try
        {
            var response = await _habitCrudService.CreateUserHabit(dto, userId);

            return CreatedAtAction(nameof(Create), response);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateHabitRequestDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            var response = await _habitCrudService.UpdateUserHabit(dto, id, userId);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            await _habitCrudService.DeleteUserHabit(id, userId);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [Authorize]
    [HttpPatch("{id}/Done")]
    public async Task<IActionResult> SetDone(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            await _habitLogicService.SetDone(id, userId);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}