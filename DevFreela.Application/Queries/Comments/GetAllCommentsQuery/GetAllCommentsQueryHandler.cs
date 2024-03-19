using DevFreela.Application.ViewModels.Comment;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Comments.GetAllCommentsQuery
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<CommentViewModel>>
    {
        private readonly IProjectRepository _repository;
        public GetAllCommentsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CommentViewModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllComments();
            
            var viewModel = projects.Select(p => new CommentViewModel(p.Id, p.Content, p.User.FullName, p.IdProject))
                .ToList();

            return viewModel;
        }
    }
}
