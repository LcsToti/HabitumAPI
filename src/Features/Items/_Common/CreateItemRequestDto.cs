using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Items._Common;

public record CreateItemRequestDto
{
    [MaxLength(25)]
    [Required(ErrorMessage = "Nome é obrigatório*")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Ícone é obrigatório*")]
    public required string Icon { get; set; }

    [Required(ErrorMessage = "Cor de ícone é obrigatória*")]
    public required string Color { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "Escolha um modo de notificações*")]
    public required bool Notifications { get; set; }
}
