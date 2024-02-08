using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    void Create(Project project);
    void Update(Project project);
    void Delete(int id);
    
}