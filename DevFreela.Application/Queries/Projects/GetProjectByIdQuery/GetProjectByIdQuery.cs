using DevFreela.Application.ViewModels.Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetProjectByIdQuery
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
