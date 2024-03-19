using DevFreela.Application.ViewModels.Project;
using DevFreela.Application.ViewModels.Skill;
using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.User.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _repository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            var skills = await _repository.GetSkillAsync(request.Id);
            var projects = user.FreelanceProjects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();

            var skillViewModel = skills.Select(p => new SkillViewModel(p.Skill.Id, p.Skill.Description)).ToList();

            var userViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, skillViewModel, projects);

            return userViewModel;
        }
    }
}
