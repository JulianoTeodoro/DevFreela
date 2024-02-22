using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels.Project;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        void Start(int id);
        void Finish(int id);
        
    }
}