
namespace Domain.Common;

public abstract class AuditableEntity : IAuditable
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
    public bool IsDeleted { get; set; }
}