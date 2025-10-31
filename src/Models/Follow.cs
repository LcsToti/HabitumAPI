using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitumAPI.Models;

[PrimaryKey(nameof(UserId), nameof(FollowingUserId))]
public class Follow
{
    [Required]
    public required int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    [Required]
    public required int FollowingUserId { get; set; }

    [ForeignKey("FollowingUserId")]
    public User FollowingUser { get; set; } = null!;

    [Required]
    public DateTime FollowingSince { get; set; } = DateTime.UtcNow;
}