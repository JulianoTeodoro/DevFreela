using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {

        public User(string fullName, string email, DateTime birthDate) {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            FreelanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }        
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public List<UserSkill> Skills { get; private set; }
        public List<Project> FreelanceProjects { get; set; }
        public List<Project> OwnedProjects { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}