using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Application.ViewModels.Skill;
using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _dbContext;

    public UserService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UserDetailsViewModel GetById(int id)
    {

        var user = _dbContext.Users
            .Include(p => p.FreelanceProjects)
            .Include(p => p.Skills)
            .SingleOrDefault(p => p.Id == id);

        var skills = _dbContext.UserSkills.Where(p => p.IdUser == id).Include(p => p.Skill).Select(p => new SkillViewModel(p.Skill.Id, p.Skill.Description)).ToList();
        var projects = user.FreelanceProjects.Select(p => new ProjectViewModel(p.Title, p.CreatedAt)).ToList();

        var userViewModel = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate, skills, projects);

        return userViewModel;
    }

}