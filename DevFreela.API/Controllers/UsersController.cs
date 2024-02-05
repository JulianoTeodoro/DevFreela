using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {


        [HttpGet("{id}")]
        public IActionResult GetById (int id) {
            return Ok(id);
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