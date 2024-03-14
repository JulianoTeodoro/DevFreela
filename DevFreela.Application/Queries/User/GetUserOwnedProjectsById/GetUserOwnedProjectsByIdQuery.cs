using DevFreela.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.User.GetUserOwnedProjectsById
{
    public class GetUserOwnedProjectsByIdQuery : IRequest<UserDetailsViewModel>
    {
        public int Id { get; set; }
        public GetUserOwnedProjectsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
