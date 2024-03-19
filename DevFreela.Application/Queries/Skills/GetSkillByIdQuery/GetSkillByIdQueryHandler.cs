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

namespace DevFreela.Application.Queries.Skills.GetSkillByIdQuery
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillViewModel>
    {
        private readonly ISkillRepository _repository;

        public GetSkillByIdQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _repository.GetById(request.Id);

            var skillViewModel = new SkillViewModel(skill.Id, skill.Description);

            return skillViewModel;
        }
    }
}
