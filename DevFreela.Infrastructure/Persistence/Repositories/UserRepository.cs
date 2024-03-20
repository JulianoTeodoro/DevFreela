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
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(p => p.Id == id);

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _dbContext
                .Users
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .ToListAsync();

            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users
                .Where(p => p.Id == id)
                .Include(p => p.OwnedProjects)
                .Include(p => p.FreelanceProjects)
                .Include(p => p.Skills)
                .SingleOrDefaultAsync();

            return user;
        }

        public async Task<User> GetByEmailAndPassword(string email, string passwordHash)
        {
            return await _dbContext.Users
                .Where(p => p.Email == email && p.Password == passwordHash)
                .SingleOrDefaultAsync();
        }


        public async Task<List<UserSkill>> GetSkillAsync(int id)
        {
            var userSkill = await _dbContext.UserSkills.Where(p => p.IdUser == id).Include(p => p.Skill).ToListAsync();

            return userSkill;
        }

        public async Task Update(User type)
        {
            var user = await _dbContext.Users.Where(p => p.Id == type.Id).SingleOrDefaultAsync();

            if(user != null)
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
