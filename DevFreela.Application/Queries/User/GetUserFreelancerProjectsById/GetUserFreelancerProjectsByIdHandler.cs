﻿using DevFreela.Application.ViewModels.Project;
using DevFreela.Application.ViewModels.Skill;
using DevFreela.Application.ViewModels.User;
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
        private readonly DevFreelaDbContext _dbContext;

        public GetUserFreelancerProjectsByIdHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserFreelancerProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Where(p => p.Id == request.Id).Include(p => p.Skills).Include(p => p.FreelanceProjects).SingleOrDefaultAsync();

            var freelancerProjects = user.OwnedProjects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt, p.Client.FullName, p.Freelancer.FullName)).ToList();
            var skills = user.Skills.Select(p => new SkillViewModel(p.SkillId, p.Skill.Description)).ToList();

            var userViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, skills, freelancerProjects);

            return userViewModel;
        }
    }
}
