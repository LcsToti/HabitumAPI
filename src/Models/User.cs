using System.ComponentModel.DataAnnotations;

namespace HabitumAPI.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Password { get; set; }

    [Required]
    public string ProfilePic { get; set; }

    [Required]
    public required string TimeZone { get; set; }

    [Required]
    [Range(0, 5, ErrorMessage = "Número de freezes fora do Intervalo Permitido")]
    public int Freezes { get; set; }

    [Required]
    public int Streak { get; set; }

    [Required]
    public int LongestStreak { get; set; }

    [Required]
    public int WeekScore { get; set; }

    [Required]
    public int LastWeekScore { get; set; }

    [Required]
    public int TotalScore { get; set; }

    [Required]
    public int Rank { get; set; }

    public string? ExpoToken { get; set; }

    [Required]
    public List<Habit> Habits { get; set; } = [];

    [Required]
    public List<Todo> Todos { get; set; } = [];


    public ICollection<UserChallenge> UserChallenges { get; set; } = new List<UserChallenge>();

    public DateTime CreatedAt { get; set; }

    #region UserDataRefreshProperties
    [Required]
    public DateTime LastDataRefresh { get; set; }

    [Required]
    public DateTime LastFreezeIncrease { get; set; }

    [Required]
    public DateTime LastFreezeDecrease { get; set; }

    [Required]
    public DateTime LastStreakIncrease { get; set; }

    [Required]
    public DateTime LastStreakReset { get; set; }

    [Required]
    public DateTime LastRankUpdate { get; set; }

    [Required]
    public int LastRank { get; set; }

    [Required]
    public DateTime LastWeekScoreReset { get; set; }

    [Required]
    public DateTime LastChallengesReset { get; set; }
    #endregion

    public User()
    {
        ProfilePic = "icon-1";

        // Evita múltiplas execuções no primeiro dia
        LastDataRefresh = DateTime.Today;
        LastFreezeIncrease = DateTime.Today;
        LastFreezeDecrease = DateTime.Today.AddDays(-1);
        LastStreakReset = DateTime.Today;
        LastStreakIncrease = DateTime.Today.AddDays(-1);
        
        LastRankUpdate = DateTime.Today.AddDays(-7); // Força update no próximo domingo
        LastWeekScoreReset = DateTime.Today.AddDays(-7); // Força update no próximo domingo
        LastChallengesReset = DateTime.Today.AddDays(-7); // Força update no próximo domingo

        CreatedAt = DateTime.UtcNow;

        WeekScore = 0;
        LastWeekScore = 0;
        TotalScore = 0;
        LongestStreak = 0;
        Streak = 0;
        Freezes = 0;
        Rank = 0;
        LastRank = 0;
    }

    public int MaxFreezes
    {
        get
        {
            if (RankToMaxFreezes.TryGetValue(Rank, out int max))
                return max;
            return 1;
        }
    }

    private static readonly Dictionary<int, int> RankToMaxFreezes = new()
    {
        { 0, 1 },
        { 1, 2 },
        { 2, 3 },
        { 3, 4 },
        { 4, 5 }
    };
}