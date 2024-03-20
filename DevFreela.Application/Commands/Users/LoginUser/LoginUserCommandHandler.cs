using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;


        public LoginUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _repository.GetByEmailAndPassword(request.Login, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginViewModel = new LoginUserViewModel(user.Email, token);

            return loginViewModel;

        }
    }
}
