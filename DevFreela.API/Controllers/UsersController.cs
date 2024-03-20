using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Models;
using DevFreela.Application.Commands.Users.CreateUser;
using DevFreela.Application.Commands.Users.LoginUser;
using DevFreela.Application.Queries.User.GetUserByIdQuery;
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
        public async Task<IActionResult> Register([FromBody] CreateUserCommand createUserModel) {

            var user = await _mediator.Send(createUserModel);

            return CreatedAtAction(nameof(GetById), new { id = user }, createUserModel);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand login) {
            var loginUserViewModel = await _mediator.Send(login);

            if (loginUserViewModel == null) return BadRequest();

            return Ok(loginUserViewModel);
        }
    }
}