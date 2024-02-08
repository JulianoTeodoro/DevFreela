namespace DevFreela.Application.InputModels.Skill;

public class NewSkillInputModel
{
    public NewSkillInputModel(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
}