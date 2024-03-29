﻿using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<UserSkill>> GetSkillAsync(int id);
        Task<User> GetByEmailAndPassword(string email, string passwordHash);
    }
}
