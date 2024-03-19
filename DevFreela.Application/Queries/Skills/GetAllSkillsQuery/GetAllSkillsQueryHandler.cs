using DevFreela.Application.ViewModels.Skill;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Skills.GetAllSkillsQuery
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _repository;

        public GetAllSkillsQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAll();
                
            var skillViewModel = skills.Select(p => new SkillViewModel(p.Id, p.Description)).ToList();

            return skillViewModel;
        }
    }
}
