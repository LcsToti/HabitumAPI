namespace HabitumAPI.Features.Users.Dtos;

public record UserServiceResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string ProfilePic { get; set; }
    public required int Freezes { get; set; }
    public required int Streak { get; set; }
    public required int LongestStreak { get; set; }
    public required int WeekScore { get; set; }
    public required int LastWeekScore { get; set; }
    public required int TotalScore { get; set; }
    public required int Rank { get; set; }
    public required int LastRank { get; set; }
    public string? ExpoToken { get; set; }
    public required DateTime LastFreezeDecrease { get; set; }
    public required DateTime LastStreakIncrease { get; set; }
    public required DateTime LastRankUpdate { get; set; }
}
