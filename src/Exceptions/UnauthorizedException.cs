namespace HabitumAPI.Exceptions;
public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base("Requisição não autorizada.") { }

    public UnauthorizedException(string message) : base(message) { }
}