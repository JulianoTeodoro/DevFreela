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

namespace DevFreela.Application.Queries.User.GetUserOwnedProjectsById
{
    public class GetUserOwnedProjectsByIdHandler : IRequestHandler<GetUserOwnedProjectsByIdQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserOwnedProjectsByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserOwnedProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            var ownedProjects = user.FreelanceProjects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt, p.Client.FullName, p.Freelancer.FullName)).ToList();
            var skills = user.Skills.Select(p => new SkillViewModel(p.SkillId, p.Skill.Description)).ToList();

            var userViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, skills, ownedProjects);

            return userViewModel;
        }
    }
}
