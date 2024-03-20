using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Interfaces;
using DevFreela.API.Models;
using DevFreela.Application.Commands.Comments;
using DevFreela.Application.Commands.Projects;
using DevFreela.Application.Commands.Projects.FinishProject;
using DevFreela.Application.Commands.Projects.StartProject;
using DevFreela.Application.Queries.Comments.GetCommentsByIdProjectQuery;
using DevFreela.Application.Queries.Projects.GetAllProjectsQuery;
using DevFreela.Application.Queries.Projects.GetProjectByIdQuery;
using DevFreela.Application.ViewModels.Comment;
using DevFreela.Application.ViewModels.Project;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    [Authorize(Roles = "admin")]
    public class ProjectsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProjectViewModel>>> Get()
        {

            var projects = await _mediator.Send(new GetAllProjectsQuery());

            return projects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsViewModel>> GetById (int id)
        {

            var project = await _mediator.Send(new GetProjectByIdQuery(id));

            if (project == null)
            {
                return BadRequest();
            }
            
            return project;
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] CreateProjectCommand createProject) {
            if (createProject.Title.Length > 50) {
                return BadRequest();
            }

            var id = await _mediator.Send(createProject);

            return CreatedAtAction(nameof(GetById), new { Id = id }, createProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] UpdateProjectCommand updateProject) {
            
            if(updateProject.Description.Length > 200) {
                return BadRequest();
            }

            var project = await _mediator.Send(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {

            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<List<CommentViewModel>>> GetCommentsByProjectId(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));

            if (project == null)
                return BadRequest("Projeto não encontrado");

            var comments = await _mediator.Send(new GetCommentsByIdProjectQuery(id));

            return comments;
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment (int id, [FromBody] CreateCommentCommand createComment) {

            var project = await _mediator.Send(new GetProjectByIdQuery(id));

            if (project == null)
                return BadRequest("Projeto não encontrado");

            var comment = await _mediator.Send(createComment);

            return CreatedAtAction(nameof(GetById), new { Id = id }, createComment);
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start (int id) {
            await _mediator.Send(new StartProjectCommand { Id = id });
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish (int id) {
            await _mediator.Send(new FinishProjectCommand { Id = id });
            return NoContent();
        }

    }
}