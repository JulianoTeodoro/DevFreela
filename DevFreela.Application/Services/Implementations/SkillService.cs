using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Skill;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;

    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _dbContext.Skills;

        var skillsViewModel = skills.Select(p => new SkillViewModel(p.Id, p.Description)).ToList();
        
        return skillsViewModel;
    }

}