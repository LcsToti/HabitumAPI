using Microsoft.EntityFrameworkCore;

namespace HabitumAPI.Models;

public class HabitumContext(DbContextOptions<HabitumContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Habit> Habits { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<UserChallenge> UserChallenges { get; set; }
}
