using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitumAPI.Models;

public abstract class Item
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required int UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }

    [MaxLength(25)]
    public required string Name { get; set; }

    [Required]
    public required string Icon { get; set; }

    [Required]
    public required string Color { get; set; }

    public required string? Description { get; set; }

    public bool Notifications { get; set; }
}