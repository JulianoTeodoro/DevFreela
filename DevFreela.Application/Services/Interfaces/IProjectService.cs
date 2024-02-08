using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.InputModels.Comment;
using DevFreela.Application.InputModels.Project;
using DevFreela.Application.ViewModels.Project;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        int Create(NewProjectInputModel inputModel);
        void CreateComment(CreateCommentInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
        
    }
}