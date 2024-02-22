using DevFreela.Application.ViewModels.Comment;
using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, 
            decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public string ClientFullName { get; set; }
        public string FreelancerFullName { get; set; }

    }
}