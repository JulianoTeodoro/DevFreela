using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        { 
            _userService = userService;
        }


        [HttpGet("{id}")]
        public ActionResult<User> GetById (int id) {

            var user = _userService.GetById(id);
            return Ok(user);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel) {
            if (createUserModel.userName.Length > 50) {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login) {
            return NoContent();
        }
    }
}