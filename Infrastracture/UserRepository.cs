using Application.Contract;
using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email==email);
        }

        public IQueryable<User> GetByRole(UserRole role)
        {
            return _context.Users.Where(u => u.Role==role);
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username==username);
        }

       
    }
}
