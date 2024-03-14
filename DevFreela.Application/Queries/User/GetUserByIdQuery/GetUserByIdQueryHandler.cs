using DevFreela.Application.ViewModels.Project;
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

namespace DevFreela.Application.Queries.User.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetUserByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(p => p.FreelanceProjects)
                .Include(p => p.Skills)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            var skills = await _dbContext.UserSkills.Where(p => p.IdUser == request.Id).Include(p => p.Skill).Select(p => new SkillViewModel(p.Skill.Id, p.Skill.Description)).ToListAsync();
            var projects = user.FreelanceProjects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();

            var userViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, skills, projects);

            return userViewModel;
        }
    }
}
