namespace HabitumAPI.Features.Auth.Utils;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        const int workFactor = 12;
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
    }
    public static bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}