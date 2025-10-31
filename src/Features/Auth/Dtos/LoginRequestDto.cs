using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Auth.Dtos;

public record LoginRequestDto
{
    [EmailAddress(ErrorMessage = "Email inválido.")]
    [Required(ErrorMessage = "Email é obrigatório.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória.")]
    public required string Password { get; set; }
}