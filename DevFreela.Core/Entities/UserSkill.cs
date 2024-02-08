using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int skillId) {
            IdUser = idUser;
            SkillId = skillId;
        }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        
        public int SkillId { get; private set; }
        public Skill Skill { get; private set; }
    }
}