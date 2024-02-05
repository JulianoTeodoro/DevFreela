using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Interfaces;
using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(IExampleClass exampleClass) {
            exampleClass.Title = "Updated at Products Controller";
        }
        
        [HttpGet]
        public IActionResult Get(){
            return Ok("Mensagem");
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id) {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] CreateProjectModel createProject) {
            if (createProject.Title.Length > 50) {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, [FromBody] UpdateProjectModel updateProject) {
            
            if(updateProject.Description.Length > 200) {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id) {
            
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment (int id, [FromBody] CreateCommentModel createComment) {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start (int id) {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish (int id) {
            return NoContent();
        }

    }
}