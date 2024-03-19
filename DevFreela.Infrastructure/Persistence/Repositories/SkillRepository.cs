using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Skill> Create(Skill entity)
        {
            var skill = new Skill(entity.Description);

            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();

            return skill;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Skill>> GetAll()
        {
            var skills = await _dbContext.Skills.ToListAsync();

            return skills;
        }

        public async Task<Skill> GetById(int id)
        {
            var skill = await _dbContext.Skills.Where(p => p.Id == id).SingleOrDefaultAsync();

            return skill;
        }

        public Task Update(Skill type)
        {
            throw new NotImplementedException();
        }
    }
}
