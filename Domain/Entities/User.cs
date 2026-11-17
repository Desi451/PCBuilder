using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<int>, IAuditable
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
    public bool IsDeleted { get; set; }
}
