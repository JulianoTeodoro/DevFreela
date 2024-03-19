using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.StartProject
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
