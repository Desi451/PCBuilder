using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Interfaces.Repository;

public interface IUserRepository
{
    Task Add(User user);
    Task Update(User user);
    Task Delete(int id);
    Task ConfirmMail(int id);
    Task Save();
}
