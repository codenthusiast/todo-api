using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.DTOs;
using TodoApi.Core.Entities;

namespace TodoApi.Core.Interfaces
{
    public interface ITaskService
    {
        Task<GetTaskDTO> CreateTask(CreateTaskDTO task);
        Task<GetTaskDTO> GetTask(int taskId);
        Task<IEnumerable<GetTaskDTO>> GetTasksForUser(int userId);
        Task<IEnumerable<GetTaskDTO>> GetAllTasks();
        Task UpdateTask(CreateTaskDTO dto, UserTask existing);
        Task SetTaskAsDone(int taskId);
        Task DeleteTask(int id);
        Task<UserTask> GetTaskForUpdate(int taskId);
    }
}
