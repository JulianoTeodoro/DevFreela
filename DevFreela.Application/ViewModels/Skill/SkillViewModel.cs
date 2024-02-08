namespace DevFreela.Application.ViewModels.Skill;

public class SkillViewModel
{

    public SkillViewModel(int id, string description)
    {
        Id = id;
        Description = description;
    }
    public int Id { get; private set; }
    public string Description { get; set; }
}