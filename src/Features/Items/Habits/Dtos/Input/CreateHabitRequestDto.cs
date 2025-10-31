using HabitumAPI.Features.Items._Common;
using HabitumAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Items.Habits.Dtos.Input;

public record CreateHabitRequestDto : CreateItemRequestDto
{
    [Required(ErrorMessage = "Selecione uma frequência válida*")]
    public required TypeFrequency Frequency { get; set; }

    public List<int>? WeekDays { get; set; }

    public int? Interval { get; set; }

    [Required(ErrorMessage = "Modo alerta é obrigatório*")]
    public required bool AlertHour { get; set; }

    public DateTime? AlertHourTime { get; set; }

    [Required(ErrorMessage = "Meta é obrigatória*")]
    public required string Goal { get; set; }
}