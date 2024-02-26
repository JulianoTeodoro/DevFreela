using DevFreela.Application.ViewModels.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Skills.GetAllSkillsQuery
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
