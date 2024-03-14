using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Models;
using DevFreela.Application.Queries.User.GetUserByIdQuery;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) 
        { 
            _mediator = mediator;
        }


        [HttpGet("GetById")]
        public async Task<UserDetailsViewModel> GetById ([FromBody] GetUserByIdQuery query) {

            var user = await _mediator.Send(query);
            return user;
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