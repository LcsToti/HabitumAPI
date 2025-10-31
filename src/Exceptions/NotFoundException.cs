namespace HabitumAPI.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException() : base("Recurso não encontrado.") { }

    public NotFoundException(string message) : base(message) { }
}