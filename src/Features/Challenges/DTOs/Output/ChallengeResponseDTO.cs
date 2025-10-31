namespace HabitumAPI.Features.Challenges.DTOs.Output;

public class ChallengeResponseDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Points { get; set; }
    public required bool? IsCompleted { get; set; }
    public string? Image { get; set; }
}