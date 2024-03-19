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

namespace DevFreela.Application.Queries.User.GetUserFreelancerProjectsById
{
    public class GetUserFreelancerProjectsByIdHandler : IRequestHandler<GetUserFreelancerProjectsByIdQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _repository;

        public GetUserFreelancerProjectsByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserFreelancerProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            var freelancerProjects = user.OwnedProjects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt, p.Client.FullName, p.Freelancer.FullName)).ToList();

            var skills = user.Skills.Select(p => new SkillViewModel(p.SkillId, p.Skill.Description)).ToList();

            var userViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, skills, freelancerProjects);

            return userViewModel;
        }
    }
}
