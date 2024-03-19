using DevFreela.Application.ViewModels.Comment;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Core.Repositories;
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
        private readonly IProjectRepository _ProjectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _ProjectRepository.GetAll();

            var projectViewModel = projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt, p.Client.FullName, p.Freelancer.FullName)).ToList();

            return projectViewModel;
        }
    }
}
