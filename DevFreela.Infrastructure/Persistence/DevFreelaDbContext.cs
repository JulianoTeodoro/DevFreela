using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {

        public DevFreelaDbContext() {
            Projects = new List<Project>{
                new Project("Meu projeto AspNETCore 1", "Minha descrição", 1, 1, 10000),
                new Project("Meu projeto AspNETCore 2", "Minha descrição", 1, 1, 10000),
                new Project("Meu projeto AspNETCore 3", "Minha descrição", 1, 1, 10000),
                new Project("Meu projeto AspNETCore 4", "Minha descrição", 1, 1, 10000)
            };

            Users = new List<User> {
                new User("Juliano", "juliano@gmail.com", new DateTime(2002, 9, 28)),
                new User("Andre", "andre@gmail.com", new DateTime(1990, 1, 5)),
                new User("Vinicius", "vinicius@gmail.com", new DateTime(2002, 5, 4)),
            };

            Skills = new List<Skill> {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };

        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}