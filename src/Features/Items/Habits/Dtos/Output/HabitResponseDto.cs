using HabitumAPI.Features.Items._Common;
using HabitumAPI.Models;

namespace HabitumAPI.Features.Items.Habits.Dtos.Output;

public record HabitResponseDto : ItemResponseDto
{
    public required TypeFrequency Frequency { get; set; }
    public required List<int>? WeekDays { get; set; }
    public required int? Interval { get; set; }
    public required string Goal { get; set; }
    public required bool AlertHour { get; set; }
    public required DateTime? AlertHourTime { get; set; }
    public required HabitStatus Status { get; set; }
    public required DateTime NextDayToBeDone { get; set; }
}
