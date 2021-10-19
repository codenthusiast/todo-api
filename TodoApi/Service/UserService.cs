using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<User> CreateUser(User user)
        {
            var result = await _userRepository.CreateAsync(user);
            return result;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
