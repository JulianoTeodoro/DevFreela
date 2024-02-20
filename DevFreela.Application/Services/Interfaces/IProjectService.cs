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
        Task<ProjectDetailsViewModel> GetById(int id);
        void Start(int id);
        void Finish(int id);
        
    }
}