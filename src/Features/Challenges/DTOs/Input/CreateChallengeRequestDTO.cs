using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Challenges.DTOs.Input;

public class CreateChallengeRequestDTO
{
    [MaxLength(50)]
    [Required(ErrorMessage = "Nome é obrigatório*")]
    public required string Name { get; set; }
    [MaxLength(200)]
    [Required(ErrorMessage = "Descrição é obrigatória*")]
    public required string Description { get; set; }
    [Required(ErrorMessage = "Pontos são obrigatórios*")]
    public required int Points { get; set; }
    public string? Image { get; set; }
}
