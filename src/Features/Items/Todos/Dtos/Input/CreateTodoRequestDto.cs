using HabitumAPI.Features.Items._Common;
using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Items.Todos.Dtos.Input;

public record CreateTodoRequestDto : CreateItemRequestDto
{
    [Required(ErrorMessage = "Selecione a Data e hora")]
    public required DateTime Date { get; set; }
    
}
