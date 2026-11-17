namespace Application.Service.Common;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}
