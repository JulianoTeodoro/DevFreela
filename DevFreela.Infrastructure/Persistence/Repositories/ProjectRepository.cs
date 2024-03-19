using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> Create(Project project)
        {

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAll()
        {
            var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .ToListAsync();

            return project;
        }

        public async Task<Project> GetById(int id)
        {
            var project = await _dbContext.Projects.Where(p => p.Id == id).Include(p => p.Client).Include(p => p.Freelancer).SingleOrDefaultAsync();

            return project;
        }

        public async Task Update(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Start(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);

            project.Start();
            await _dbContext.SaveChangesAsync();
        }

        public async Task Finish(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);

            project.Finish();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProjectComment> CreateComment(ProjectComment project)
        {
            await _dbContext.ProjectComments.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project;
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _dbContext.ProjectComments.Where(p => p.Id == id).SingleOrDefaultAsync();

            _dbContext.ProjectComments.Remove(comment);
        }

        public async Task UpdateComment(ProjectComment comment)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectComment>> GetAllComments()
        {
            var comments = await _dbContext.ProjectComments
                .Include(p => p.User)
                .ToListAsync();

            return comments;
        }

        public async Task<ProjectComment> GetCommentById(int id)
        {
            var comment = await _dbContext.ProjectComments.Where(p => p.Id == id).Include(p => p.User).SingleOrDefaultAsync();

            return comment;
        }
        
        public async Task<List<ProjectComment>> GetCommentsByIdProject(int id)
        {
            var comments = await _dbContext.ProjectComments.Where(p => p.IdProject == id)
                .Include(p => p.User)
                .ToListAsync();

            return comments;
        }
    }
}
