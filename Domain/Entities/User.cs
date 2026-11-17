using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<int>
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
    public bool IsDeleted { get; set; }
}
