using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository : IRepository<Project>
{
    Task Start(int id);
    Task Finish(int id);
    Task<ProjectComment> CreateComment(ProjectComment project);
    Task DeleteComment(int id);
    Task UpdateComment(ProjectComment comment);
    Task<List<ProjectComment>> GetAllComments();
    Task<ProjectComment> GetCommentById(int id);
    Task<List<ProjectComment>> GetCommentsByIdProject(int id);

}