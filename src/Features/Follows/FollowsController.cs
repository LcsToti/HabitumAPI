using HabitumAPI.Exceptions;
using HabitumAPI.Features.Follows.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitumAPI.Features.Follows;

[ApiController]
public class FollowsController(IFollowService followService) : ControllerBase
{
    private readonly IFollowService _followService = followService;

    [HttpPost("Me/Following/{id}")]
    [Authorize]
    public async Task<IActionResult> FollowUser(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        try
        {
            await _followService.FollowUser(userId, id);

            return Ok("Usuário seguido com sucesso");
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ConflictException ex)
        {
            return Conflict(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("Me/Following/{id}")]
    [Authorize]
    public async Task<IActionResult> UnfollowUser(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        try
        {
            await _followService.UnfollowUser(userId, id);

            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("Me/Following")]
    [Authorize]
    public async Task<ActionResult> GetFollowing()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var followingList = await _followService.GetUserFollowing(userId);
        return Ok(followingList);
    }

    [HttpGet("Me/Followers")]
    [Authorize]
    public async Task<ActionResult> GetFollowers()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var followersList = await _followService.GetUserFollowers(userId);
        return Ok(followersList);
    }
}
