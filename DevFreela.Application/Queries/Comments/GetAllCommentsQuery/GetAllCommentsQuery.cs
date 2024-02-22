using DevFreela.Application.ViewModels.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Comments.GetAllCommentsQuery
{
    public class GetAllCommentsQuery : IRequest<List<CommentViewModel>>
    {
        public GetAllCommentsQuery() { }
    }
}
