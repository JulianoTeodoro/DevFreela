using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    UserDetailsViewModel GetById(int id);
}