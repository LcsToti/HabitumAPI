using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; private set; }
        [Required]
        public int Points { get; private set; }
        public string? Image { get; private set; }
        public ICollection<UserChallenge> UserChallenges { get; set; } = [];

        public Challenge(string name, string description, int points, string? image)
        {
            Name = name;
            Description = description;
            Points = points;
            Image = image;
        }

        public void Update(string? name, string? description, int? points, string? image)
        {
            if (!string.IsNullOrWhiteSpace(name)) { Name = name; }
            if (!string.IsNullOrWhiteSpace(description)) { Description = description; }
            if (points.HasValue) { Points = points.Value; }
            if (!string.IsNullOrWhiteSpace(image)) { Image = image; }
        }
    }
}
