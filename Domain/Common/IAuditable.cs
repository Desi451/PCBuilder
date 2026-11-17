namespace Domain.Common;

public interface IAuditable
{
    DateTime Created { get; set; }
    DateTime? LastModified { get; set; }
    bool IsDeleted { get; set; }
}
