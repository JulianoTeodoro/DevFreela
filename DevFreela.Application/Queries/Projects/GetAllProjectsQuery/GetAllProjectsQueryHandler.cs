using DevFreela.Application.ViewModels.Comment;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetAllProjectsQuery
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.Include(p => p.Client).Include(p => p.Freelancer).Select(p => new ProjectViewModel(p.Title, p.CreatedAt)).ToList();
            
            return project;
        }
    }
}
