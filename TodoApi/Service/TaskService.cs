using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.Core.Enums;
using TodoApi.Core.Interfaces;
using TodoApi.Core.Repository;

namespace TodoApi.Service
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<UserTask> _taskRepository;

        public TaskService(IBaseRepository<UserTask> repository)
        {
            _taskRepository = repository;
        }

        public async Task<UserTask> CreateTask(UserTask task)
        {
            var result = await _taskRepository.CreateAsync(task);
            return result;
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<UserTask> GetTask(int taskId)
        {
            return await _taskRepository.GetByIdAsync(taskId);
        }

        public async Task<IEnumerable<UserTask>> GetTasksForUser(int userId)
        {
            return await _taskRepository.FindAsync(t => t.UserId == userId);
        }

        public async Task SetTaskAsDone(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if(task != null)
            {
                task.State = TaskState.done;
                await _taskRepository.UpdateAsync(task);
            }
        }

        public async Task UpdateTask(UserTask task)
        {
            await _taskRepository.UpdateAsync(task);
        }
    }
}
