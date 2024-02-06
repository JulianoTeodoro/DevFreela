using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{
    public DevFreelaDbContext()
    {
        Projects = new List<Project>
        {
            new Project("Meu projeto ASP NET Core 1", "Minha descricao 1", 1, 1, 10000),
            new Project("Meu projeto ASP NET Core 2", "Minha descricao 2", 1, 1, 10000),
            new Project("Meu projeto ASP NET Core 3", "Minha descricao 3", 1, 1, 10000),
        };

        Users = new List<User>
        {
            new User("Juliano Teodoro", "juliano@gmail.com", new DateTime(2002, 9, 28)),
            new User("Andre Teodoro", "andre@gmail.com", new DateTime(1990, 1, 5)),
            new User("Nizia", "nizia@gmail.com", new DateTime(2001,03,26))
        };

        Skills = new List<Skill>
        {
            new Skill(".NET Core"),
            new Skill("C#"),
            new Skill("JavaScript")
        };
    }
    
    public List<Project> Projects { get; set; }
    public List<User> Users { get; private set; }
    public List<Skill> Skills { get; private set; }

}