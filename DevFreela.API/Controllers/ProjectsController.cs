using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Interfaces;
using DevFreela.API.Models;
using DevFreela.Application.Commands.Comments;
using DevFreela.Application.Commands.Projects;
using DevFreela.Application.Queries.Comments.GetCommentsByIdProjectQuery;
using DevFreela.Application.Queries.Projects.GetAllProjectsQuery;
using DevFreela.Application.Queries.Projects.GetProjectByIdQuery;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Comment;
using DevFreela.Application.ViewModels.Project;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
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
        public IActionResult Start (int id) {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish (int id) {
            _projectService.Finish(id);
            return NoContent();
        }

    }
}