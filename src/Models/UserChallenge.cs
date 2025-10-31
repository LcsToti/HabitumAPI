using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Models
{
    [PrimaryKey(nameof(UserId), nameof(ChallengeId), nameof(StartedAt))]
    public class UserChallenge
    {
        [Required]
        public required int UserId { get; set; }
        [Required]
        public required int ChallengeId { get; set; }
        [Required]
        public required DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; } = null;
        public User? User { get; set; }
        public Challenge? Challenge { get; set; }
        public UserChallenge() { }
        public void CompleteUserChallenge(DateTime date)
        {
            if (CompletedAt.HasValue)
                throw new InvalidOperationException("Este desafio já foi completado.");

            CompletedAt = date;
        }
    }
}
