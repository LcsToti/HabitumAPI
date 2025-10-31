using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Models;

public class Todo : Item
{
    [Required]
    public required DateTime Date { get; set; }

    [Required]
    public required ToDoStatus Status { get; set; }

    public DateTime? CompletedAt { get; set; }

}

public enum ToDoStatus
{
    pending,
    done,
    inactive
}
