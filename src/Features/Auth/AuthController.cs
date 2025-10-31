using HabitumAPI.Exceptions;
using HabitumAPI.Features.Auth.Dtos;
using HabitumAPI.Features.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HabitumAPI.Features.Auth;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthServices authServices) : Controller
{
    private readonly IAuthServices _authService = authServices;

    [Route("/Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        try
        {
            var response = await _authService.Register(dto);

            return StatusCode(201, response);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
        catch (BadRequestException ex) 
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno no servidor: \n {ex.Message}");
        }
    }

    [HttpPost]
    [Route("/Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        try
        {
            var response = await _authService.Login(dto);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno no servidor: \n {ex.Message}");
        }
    }
}
