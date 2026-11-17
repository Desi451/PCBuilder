namespace Application.Interfaces;

public interface ICurrentUser
{
    int Id { get; }
    bool IsAdminOrAbove { get; }
}
