using DevFreela.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.User.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
    }
}
