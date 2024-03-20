using DevFreela.Application.Commands.Users.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email nao valido!");
            RuleFor(x => x.Password).Must(ValidPassword).WithMessage("Senha precisa no minimo de oito caracteres, pelo menos uma letra, um número e um caractere especial");

            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("Nome é obrigatorio");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");

            return regex.IsMatch(password);
        }
    }
}
