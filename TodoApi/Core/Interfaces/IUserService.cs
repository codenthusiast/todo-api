using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.DTOs;
using TodoApi.Core.Entities;

namespace TodoApi.Core.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(int id);
        Task<User> GetUserByIdForUpdate(int userId);
        Task UpdateUser(CreateUserDTO update, User existing);
        Task<GetUserDTO> CreateUser(CreateUserDTO user);
        Task<IEnumerable<GetUserDTO>> GetAllUsers();
        Task<GetUserDTO> GetUserById(int userId);
    }
}
