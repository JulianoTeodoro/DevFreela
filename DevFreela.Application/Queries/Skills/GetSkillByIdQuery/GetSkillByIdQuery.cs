using DevFreela.Application.ViewModels.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Skills.GetSkillByIdQuery
{
    public class GetSkillByIdQuery : IRequest<SkillViewModel>
    {
        public int Id { get; set; }
        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }
    }
}
