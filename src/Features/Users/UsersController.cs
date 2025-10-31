using HabitumAPI.Exceptions;
using HabitumAPI.Features.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitumAPI.Features.Users;

[Route("[controller]")]
[ApiController]
public class UsersController(IUserCrudService userCrudService) : ControllerBase
{
    private readonly IUserCrudService _userCrudService = userCrudService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _userCrudService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var response = await _userCrudService.GetById(id);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("TopRank")]
    public async Task<IActionResult> GetTopRankedUsers()
    {
        var response = await _userCrudService.GetTopRankedUsers();
        return Ok(response);
    }

    [Authorize]
    [HttpGet("/Me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        try
        {
            var user = await _userCrudService.GetById(userId);
            return Ok(user);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpPatch("/Me/UpdateProfilePic")]
    public async Task<IActionResult> UpdateProfilePic([FromBody] string newProfilePic)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        try
        {
            var updatedUser = await _userCrudService.UpdateProfilePic(userId, newProfilePic);
            return Ok(updatedUser);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
