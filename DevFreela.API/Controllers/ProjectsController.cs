using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Interfaces;
using DevFreela.API.Models;
using DevFreela.Application.InputModels.Comment;
using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpGet]
        public ActionResult<List<ProjectViewModel>> Get()
        {

            var projects = _projectService.GetAll("projects");

            return projects;
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDetailsViewModel> GetById (int id)
        {

            var project = _projectService.GetById(id);

            if (project == null)
            {
                return BadRequest();
            }
            
            return project;
        }

        [HttpPost]
        public IActionResult Post ([FromBody] NewProjectInputModel createProject) {
            if (createProject.Title.Length > 50) {
                return BadRequest();
            }
            
            var id = _projectService.Create(createProject);

            return CreatedAtAction(nameof(GetById), new { Id = id }, createProject);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, [FromBody] UpdateProjectInputModel updateProject) {
            
            if(updateProject.Description.Length > 200) {
                return BadRequest();
            }
            
            _projectService.Update(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {

            _projectService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment (int id, [FromBody] CreateCommentInputModel createComment) {
            
            _projectService.CreateComment(createComment);
            return NoContent();
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