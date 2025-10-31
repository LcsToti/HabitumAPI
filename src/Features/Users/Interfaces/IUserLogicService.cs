using HabitumAPI.Models;

namespace HabitumAPI.Features.Users.Interfaces;

public interface IUserLogicService
{
    #region EventDrivenLogic
    Task TryIncreaseUserStreak(int id);
    Task IncreaseWeekScore(int id);
    #endregion

    #region DailyRefresh
    Task RefreshUserData(int id); // Roda uma vez por dia, é chamada pelo middleware se user.LastDataRefresh for diferente de hoje
    Task ClearUserChallenges(User user);
    Task TryIncreaseFreezes(User user);
    Task TryResetStreak(User user);
    Task TryUpdateRankUtc(User user);
    Task TryResetWeekScoreUtc(User user);
    Task TrySetHabitsNextDayToBeDone(User user);
    Task SetUserItemsStatus(User user);
    #endregion
}
