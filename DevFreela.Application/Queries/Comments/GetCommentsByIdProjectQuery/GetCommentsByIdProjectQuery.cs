using DevFreela.Application.ViewModels.Comment;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Comments.GetCommentsByIdProjectQuery
{
    public class GetCommentsByIdProjectQuery : IRequest<List<CommentViewModel>>
    {
        public int Id { get; private set; }
        public GetCommentsByIdProjectQuery(int id) 
        {
            Id = id;
        }
    }
}
