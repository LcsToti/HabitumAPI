using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Challenges.DTOs.Input;

public class UpdateChallengeRequestDTO
{
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public int? Points { get; set; }
    public string? Image { get; set; }
}
