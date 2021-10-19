using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.DTOs;
using TodoApi.Core.Entities;
using TodoApi.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<GetUserDTO>> Get()
        {
            var users = await _userService.GetAllUsers();
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDTO>> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if(user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<GetUserDTO>> Post([FromBody] CreateUserDTO user)
        {
            var newUser = await _userService.CreateUser(user);
            return CreatedAtAction(actionName: nameof(Get), routeValues: new { id = newUser.Id}, newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateUserDTO update)
        {
            var userToUpdate = await _userService.GetUserByIdForUpdate(id);
            if(userToUpdate == null)
            {
                return NotFound();
            }
            await _userService.UpdateUser(update, userToUpdate);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToUpdate = await _userService.GetUserById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
