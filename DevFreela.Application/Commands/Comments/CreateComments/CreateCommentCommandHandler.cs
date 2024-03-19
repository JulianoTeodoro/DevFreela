using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Comments
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var createComment = _projectRepository.CreateComment(new ProjectComment(request.Content, request.IdProject, request.IdUser));
            return createComment.Id;
        }
    }
}
