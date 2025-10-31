using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Items._Common;

public record UpdateItemRequestDto
{
    [MaxLength(25)]
    public string? Name { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public bool? Notifications { get; set; }
}
