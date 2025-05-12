using Applications.DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        UserDTO Register(User user);
        UserDTO Login(string username, string password);
        UserDTO GetUserById(int id);
        List<UserDTO> GetAllClients();
        List<UserDTO> GetAllAdmins();
        UserDTO UpdateUser(User user);
        void DeactivateUser(int id);
        void ActivateUser(int id);
    }
}
