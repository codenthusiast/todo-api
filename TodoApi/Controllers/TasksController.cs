using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IEnumerable<UserTask>> Get()
        {
            var users = await _taskService.GetAllTasks();
            return users;
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> Get(int id)
        {
            var user = await _taskService.GetTask(id);
            if (user == null)
            {
                return NotFound("Task not found");
            }
            return Ok(user);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<ActionResult<UserTask>> Post([FromBody] UserTask user)
        {
            var newUserTask = await _taskService.CreateTask(user);
            return CreatedAtAction(nameof(Get), new { id = newUserTask.Id });
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserTask user)
        {
            var userToUpdate = await _taskService.GetTask(id);
            if (userToUpdate == null)
            {
                return NotFound("Task not found");
            }
            await _taskService.UpdateTask(user);
            return NoContent();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToUpdate = await _taskService.GetTask(id);
            if (userToUpdate == null)
            {
                return NotFound("Task not found");
            }
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
