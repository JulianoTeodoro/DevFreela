using DevFreela.Application.ViewModels.Comment;
using DevFreela.Core.Entities;
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
        private readonly DevFreelaDbContext _dbContext;
        public GetCommentsByIdProjectQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CommentViewModel>> Handle(GetCommentsByIdProjectQuery request, CancellationToken cancellationToken)
        {

            var project = await _dbContext.ProjectComments.Where(p => p.IdProject == request.Id)
                .Include(p => p.User)
                .Select(p => new CommentViewModel(p.Id, p.Content, p.User.FullName, p.IdProject))
                .ToListAsync();

            return project;

        }
    }
}
