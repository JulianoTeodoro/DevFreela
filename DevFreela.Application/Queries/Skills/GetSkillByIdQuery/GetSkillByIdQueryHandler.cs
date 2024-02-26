using DevFreela.Application.ViewModels.Skill;
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
        private readonly DevFreelaDbContext _dbContext;

        public GetSkillByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SkillViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _dbContext.Skills.Select(p => new SkillViewModel(p.Id, p.Description)).Where(p => p.Id == request.Id).SingleOrDefaultAsync();

            return skill;
        }
    }
}
