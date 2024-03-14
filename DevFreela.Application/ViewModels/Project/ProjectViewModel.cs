using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels.Project
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, DateTime createdAt, string clientName = null, string freelancerName = null)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
            ClientName = clientName;
            FreelancerName = freelancerName;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string ClientName { get; set; }
        public string FreelancerName { get; set; }
    }
}