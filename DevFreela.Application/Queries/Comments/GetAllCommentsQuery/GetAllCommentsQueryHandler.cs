using DevFreela.Application.ViewModels.Comment;
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
        private readonly DevFreelaDbContext _dbContext;
        public GetAllCommentsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CommentViewModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _dbContext.ProjectComments
                .Include(p => p.User)
                .Select(p => new CommentViewModel(p.Id, p.Content, p.User.FullName, p.IdProject))
                .ToListAsync();

            return projects;
        }
    }
}
