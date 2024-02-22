using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Comments.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
