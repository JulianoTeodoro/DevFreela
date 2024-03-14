using DevFreela.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.User.GetUserFreelancerProjectsById
{
    public class GetUserFreelancerProjectsByIdQuery : IRequest<UserDetailsViewModel>
    {
        public int Id { get; set; }
        public GetUserFreelancerProjectsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
