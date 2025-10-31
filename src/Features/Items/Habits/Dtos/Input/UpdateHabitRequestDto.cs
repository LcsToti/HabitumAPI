using HabitumAPI.Features.Items._Common;
using HabitumAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Features.Items.Habits.Dtos.Input;

public record UpdateHabitRequestDto : UpdateItemRequestDto
{
    public TypeFrequency? Frequency { get; set; }
    public List<int>? WeekDays { get; set; }

    public int? Interval { get; set; }
    public bool? AlertHour { get; set; }
    public DateTime? AlertHourTime { get; set; }
    public string? Goal { get; set; }
}