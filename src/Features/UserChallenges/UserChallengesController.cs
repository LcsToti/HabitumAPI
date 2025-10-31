using HabitumAPI.Exceptions;
using HabitumAPI.Features.UserChallenges.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitumAPI.Features.UserChallenges;

public class UserChallengesController(IUserChallengesService userChallengesService) : ControllerBase
{
    private readonly IUserChallengesService _userChallengesService = userChallengesService;

    [Authorize]
    [HttpGet("/Me/Challenges")]
    public async Task<IActionResult> GetWeeklyChallenges()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        try
        {
            var response = await _userChallengesService.GetWeeklyChallenges(userId);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpPatch("/Me/{challengeId}/Complete")]
    public async Task<IActionResult> CompleteChallenge(int challengeId)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        try
        {
            await _userChallengesService.CompleteChallenge(userId, challengeId);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("/Me/Challenges/Completed/Count")]
    public async Task<IActionResult> GetCompleteUserChallengesCount()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var response = await _userChallengesService.GetCompleteUserChallengesCount(userId);
        return Ok(response);
    }
}
