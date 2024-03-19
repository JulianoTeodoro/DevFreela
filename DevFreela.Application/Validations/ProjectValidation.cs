using DevFreela.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validations
{
    public class ProjectValidation : AbstractValidator<Project>
    {
        public ProjectValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.FinishedAt > x.StartedAt);
        }
    }
}
