namespace SOFTW2_Uebungen.Models.Excxeption;

public class MovieNotFoundException : Exception
{
    public MovieNotFoundException() : base("Movie not Found")
    {
    }

    public MovieNotFoundException(string message)
        : base(message)
    {
    }
}