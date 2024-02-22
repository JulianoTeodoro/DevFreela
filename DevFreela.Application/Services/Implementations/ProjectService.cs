using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DevFreela.Application.ViewModels.Comment;

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