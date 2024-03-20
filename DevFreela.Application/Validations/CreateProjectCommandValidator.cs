using DevFreela.Application.Commands.Projects;
using DevFreela.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validations
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("A descrição é obrigatoria");
            RuleFor(x => x.Description).MinimumLength(250).WithMessage("Tamanho maximo é de 250 caracteres");
            RuleFor(x => x.IdClient).NotEmpty().WithMessage("O projeto precisa de um cliente");
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("O titulo é obrigatorio");
            RuleFor(x => x.Title).MinimumLength(30).WithMessage("Tamanho maximo é de 30 caracteres");

        }
    }
}
