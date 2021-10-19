using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.DTOs;
using TodoApi.Core.Entities;
using TodoApi.Core.Interfaces;
using TodoApi.Core.Repository;

namespace TodoApi.Service
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> repository)
        {
            _userRepository = repository;
        }

        public async Task<GetUserDTO> CreateUser(CreateUserDTO user)
        {

            User entity = new User
            {
                Name = user.Name
            };
            var result = await _userRepository.CreateAsync(entity);

            return new GetUserDTO
            {
                Name = result.Name,
                Id = result.Id
            };
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUsers()
        {
            var result = await _userRepository.GetAllAsync();
            return result.Select(u => new GetUserDTO
            {
                Name = u.Name,
                Id = u.Id,
                Tasks = u.Tasks.Select(t => new GetTaskDTO
                {
                    TaskState = t.State,
                    Description = t.Description,
                    UserId = t.UserId,
                    Id = t.Id
                })

            });
        }

        public async Task<GetUserDTO> GetUserById(int userId)
        {
            var result = await _userRepository.GetByIdAsync(userId);
            if (result == null)
            {
                return null;
            }

            return new GetUserDTO
            {
                Name = result.Name,
                Id = result.Id,
                Tasks = result.Tasks.Select(t => new GetTaskDTO
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Description = t.Description,
                    TaskState = t.State
                })
            };
        }

        public async Task<User> GetUserByIdForUpdate(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task UpdateUser(CreateUserDTO update, User existing)
        {
            existing.Name = update.Name;
            await _userRepository.UpdateAsync(existing);
        }
    }
}
