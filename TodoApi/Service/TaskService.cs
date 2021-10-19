using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.DTOs;
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

        public async Task<GetTaskDTO> CreateTask(CreateTaskDTO dto)
        {
            var task = new UserTask
            {
                Description = dto.Description,
                UserId = dto.UserId,
                State = dto.TaskState
            };
            var result = await _taskRepository.CreateAsync(task);
            return new GetTaskDTO 
            {
                Description = result.Description,
                UserId = result.UserId,
                TaskState = result.State,
                Id = result.Id
            };
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetTaskDTO>> GetAllTasks()
        {
            var result =  await _taskRepository.GetAllAsync();
            var tasks = result.Select(t => new GetTaskDTO
            {
                Description = t.Description,
                TaskState = t.State,
                Id = t.Id,
                UserId = t.UserId
            });

            return tasks;
        }

        public async Task<GetTaskDTO> GetTask(int taskId)
        {
            var result =  await _taskRepository.GetByIdAsync(taskId);
            if(result == null)
            {
                return null;
            }

            var task = new GetTaskDTO
            {
                Description = result.Description,
                TaskState = result.State,
                Id = result.Id,
                UserId = result.UserId
            };

            return task;

        }

        public async Task<UserTask> GetTaskForUpdate(int taskId)
        {
            var result =  await _taskRepository.GetByIdAsync(taskId);
            if(result == null)
            {
                return null;
            }

            return result;

        }

        public async Task<IEnumerable<GetTaskDTO>> GetTasksForUser(int userId)
        {
            var result = await _taskRepository.FindAsync(t => t.UserId == userId);
            var tasks = result.Select(t => new GetTaskDTO
            {
                Description = t.Description,
                TaskState = t.State,
                Id = t.Id,
                UserId = t.UserId
            });

            return tasks;
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

        public async Task UpdateTask(CreateTaskDTO dto, UserTask existing)
        {
            existing.Description = dto.Description;
            existing.State = dto.TaskState;
            existing.UserId = dto.UserId;
            await _taskRepository.UpdateAsync(existing);
        }
    }
}
