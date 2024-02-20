using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IMediator _mediator;

        public ProjectService(DevFreelaDbContext dbContext, IMediator mediator) {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects.ToList();

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public async Task<ProjectDetailsViewModel> GetById(int id)
        {
            var project = await _dbContext.Projects
                .Include(p => p.Freelancer)
                .Include(p => p.Client)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return null;
            }

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id, 
                project.Title, 
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName,
                project.Comments
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            
            project.Start();
            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            
            project.Finish();
            _dbContext.SaveChanges();
        }
    }
}