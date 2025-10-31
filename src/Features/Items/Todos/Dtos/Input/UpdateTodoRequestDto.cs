using HabitumAPI.Features.Items._Common;

namespace HabitumAPI.Features.Items.Todos.Dtos.Input;

public record UpdateTodoRequestDto : UpdateItemRequestDto
{
    public DateTime Date { get; set; }
}
