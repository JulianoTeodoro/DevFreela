using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetProjectByIdQuery
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetProjectByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.Where(p => p.Id == request.Id).Include(p => p.Client).Include(p => p.Freelancer).SingleOrDefaultAsync();

            var projectsViewModel = new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt, project.Client.FullName, project.Freelancer.FullName);

            return projectsViewModel;
        }
    }
}
