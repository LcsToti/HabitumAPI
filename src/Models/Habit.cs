using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Models;
public class Habit : Item
{
    [Required]
    public required TypeFrequency Frequency { get; set; }

    public List<int>? WeekDays { get; set; }

    public int? Interval { get; set; }

    public bool AlertHour { get; set; }

    public DateTime? AlertHourTime { get; set; }

    [Required]
    public required string Goal { get; set; }

    [Required]
    public required HabitStatus Status { get; set; }

    [Required]
    public required DateTime NextDayToBeDone { get; set; }
}

public enum TypeFrequency
{
    Daily,
    Weekly,
    Interval
}
public enum HabitStatus
{
    Pending,
    Done,
    Inactive
}