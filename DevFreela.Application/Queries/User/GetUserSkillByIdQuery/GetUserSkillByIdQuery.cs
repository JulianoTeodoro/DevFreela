using DevFreela.Application.ViewModels.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.User.GetUserSkillByIdQuery
{
    public class GetUserSkillByIdQuery : IRequest<List<SkillViewModel>>
    {
        public GetUserSkillByIdQuery(int id) 
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
