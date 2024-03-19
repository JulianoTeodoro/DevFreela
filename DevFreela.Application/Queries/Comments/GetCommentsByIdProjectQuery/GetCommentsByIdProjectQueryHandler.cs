using DevFreela.Application.ViewModels.Comment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Comments.GetCommentsByIdProjectQuery
{
    public class GetCommentsByIdProjectQueryHandler : IRequestHandler<GetCommentsByIdProjectQuery, List<CommentViewModel>>
    {
        private readonly IProjectRepository _repository;
        public GetCommentsByIdProjectQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CommentViewModel>> Handle(GetCommentsByIdProjectQuery request, CancellationToken cancellationToken)
        {

            var project = await _repository.GetCommentsByIdProject(request.Id);

            var viewModel = project
                .Select(p => new CommentViewModel(p.Id, p.Content, p.User.FullName, p.IdProject))
                .ToList();

            return viewModel;

        }
    }
}
