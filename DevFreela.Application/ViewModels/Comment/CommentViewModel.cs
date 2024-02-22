using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public CommentViewModel(int id, string content, string userFullName, int idProject)
        {
            Id = id;
            Content = content;
            UserFullName = userFullName;
            IdProject = idProject;
        }
        public int Id { get; private set; }
        public string Content { get; private set; }
        public string UserFullName { get; private set; }
        public int IdProject { get; private set; }
    }
}
