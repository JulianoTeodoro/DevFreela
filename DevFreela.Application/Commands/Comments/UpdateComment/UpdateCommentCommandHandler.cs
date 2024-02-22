using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Comments.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public UpdateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.ProjectComments.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (comment == null) return Unit.Value;

            comment.Update(request.Content);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
            
        }
    }
}
