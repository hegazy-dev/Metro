namespace Metro.Core.Exceptions;

public class StationNotFoundException : Exception
{
    public StationNotFoundException()
    {
    }

    public StationNotFoundException(string message) : base(message)
    {
    }

    public StationNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}