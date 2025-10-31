namespace HabitumAPI.Exceptions;
public class BadRequestException : Exception
{
    public BadRequestException() : base("Requisição inválida.") { }

    public BadRequestException(string message) : base(message) { }
}