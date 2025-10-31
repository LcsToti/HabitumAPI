namespace HabitumAPI.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() : base("Conflito nos dados solicitados.") { }

    public ConflictException(string message) : base(message) { }
}