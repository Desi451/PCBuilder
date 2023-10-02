using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository;

internal interface IUserRepository
{
    List<User> GetAll();
    User GetById(int id);
    User Add(User user);
    void Update(User user);
    void Delete(int id);
}
