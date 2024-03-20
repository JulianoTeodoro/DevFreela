using DevFreela.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Users.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
