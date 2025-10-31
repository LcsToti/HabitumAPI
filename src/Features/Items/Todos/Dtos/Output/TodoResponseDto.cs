using HabitumAPI.Features.Items._Common;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Todos.Dtos.Output;

public record TodoResponseDto : ItemResponseDto
{
    public required DateTime Date { get; set; }
    public ToDoStatus Status { get; internal set; }

    public DateTime? CompletedAt { get; set; }
}
