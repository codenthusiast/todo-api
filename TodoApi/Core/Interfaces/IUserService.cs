using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;

namespace TodoApi.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
