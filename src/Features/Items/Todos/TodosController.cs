using HabitumAPI.Exceptions;
using HabitumAPI.Features.Items.Todos.Dtos.Input;
using HabitumAPI.Features.Items.Todos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitumAPI.Features.Items.Todos;

[Route("Me/[controller]")]
[ApiController]
public class TodosController(ITodoCrudService todoCrudService, ITodoLogicService todoLogicService) : ControllerBase
{
    private readonly ITodoCrudService _todoCrudService = todoCrudService;
    private readonly ITodoLogicService _todoLogicService = todoLogicService;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var response = await _todoCrudService.GetAllUserTodos(userId);

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            var response = await _todoCrudService.GetUserTodoById(id, userId);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("Pending")]
    public async Task<IActionResult> GetPending()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            var response = await _todoCrudService.GetPendingTodosbyUser(userId);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }

       
    }
    
    [Authorize]
    [HttpGet("Done")]
    public async Task<IActionResult> GetDone()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            var response = await _todoCrudService.GetDoneTodosbyUser(userId);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        } 
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        if (!ModelState.IsValid)
            return ValidationProblem();

        var response = await _todoCrudService.CreateUserTodo(dto, userId);

        return CreatedAtAction(nameof(Create), response);
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateTodoRequestDto dto)
    {
        if (!ModelState.IsValid)
            return ValidationProblem();

        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            var response = await _todoCrudService.UpdateUserTodo(dto, id, userId);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    // DELETE: /todos/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            await _todoCrudService.DeleteUserTodo(id, userId);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [Authorize]
    [HttpPatch("{id}/Done")]
    public async Task<IActionResult> SetDone(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var date = DateTime.UtcNow.Date;

        try
        {
            await _todoLogicService.SetDone(id, userId, date);
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

