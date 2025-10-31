using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Auth.Dtos;

public record RegisterRequestDTO
{
    [Required(ErrorMessage = "Campo obrigatório!")]
    [MinLength(3)]
    public required string Name { get; set; }

    [MaxLength(100)]
    [EmailAddress(ErrorMessage = "Email inválido!")]
    [Required(ErrorMessage = "Campo obrigatório!")]
    public required string Email { get; set; }

    [MaxLength(255)]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&/#^()\-_=+{}[\]:;""'<>,.|\\]).{8,}$",
        ErrorMessage = "A senha deve conter no mínimo 8 caracteres, incluindo maiúsculas, minúsculas, número e símbolo."
    )]
    [Required(ErrorMessage = "Campo obrigatório!")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "TimeZone necessária.")]
    public required string TimeZone { get; set; }
}