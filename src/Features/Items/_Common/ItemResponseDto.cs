namespace HabitumAPI.Features.Items._Common;

public record ItemResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Icon { get; set; }
    public required string Color { get; set; }
    public required string? Description { get; set; }
    public required bool Notifications { get; set; }
}
