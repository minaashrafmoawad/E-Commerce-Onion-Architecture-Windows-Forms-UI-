using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Application.Contract
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User? GetByUsername(string username);
        User? GetByEmail(string email);
        IQueryable<User> GetByRole(UserRole role);
    }
}
