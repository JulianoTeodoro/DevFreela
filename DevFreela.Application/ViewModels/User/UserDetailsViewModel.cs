using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels.Project;
using DevFreela.Application.ViewModels.Skill;
using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels.User
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string fullName, string email, DateTime birthDate, List<SkillViewModel> skills, List<ProjectViewModel> freelancerProjects)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills;
            FreelancerProjects = freelancerProjects;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<SkillViewModel>? Skills { get; private set; }
        public List<ProjectViewModel>? FreelancerProjects { get; set; }
    }
}
