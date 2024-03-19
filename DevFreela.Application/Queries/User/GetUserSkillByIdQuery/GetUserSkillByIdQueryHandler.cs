using DevFreela.Application.ViewModels.Skill;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.User.GetUserSkillByIdQuery
{
    public class GetUserSkillByIdQueryHandler : IRequestHandler<GetUserSkillByIdQuery, List<SkillViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserSkillByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<SkillViewModel>> Handle(GetUserSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skills = await _userRepository.GetSkillAsync(request.Id);

            var skillViewModel = skills.Select(p => new SkillViewModel(p.Skill.Id, p.Skill.Description)).ToList();

            return skillViewModel;

        }
    }
}
