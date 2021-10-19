using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;

namespace TodoApi.Core.Interfaces
{
    public interface ITaskService
    {
        Task<UserTask> CreateTask(UserTask task);
        Task<UserTask> GetTask(int taskId);
        Task<IEnumerable<UserTask>> GetTasksForUser(int userId);
        Task<IEnumerable<UserTask>> GetAllTasks();
        Task UpdateTask(UserTask task);
        Task SetTaskAsDone(int taskId);
        Task DeleteTask(int id);
    }
}
