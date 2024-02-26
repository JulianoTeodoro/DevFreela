using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Services.Implementations;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Commands.Projects;
using DevFreela.Application.Commands.Comments;
using DevFreela.Application.Queries.Projects.GetAllProjectsQuery;
using DevFreela.Application.Queries.Projects.GetProjectByIdQuery;
using DevFreela.Application.Queries.Comments.GetCommentsByIdProjectQuery;
using DevFreela.Application.Queries.Skills.GetAllSkillsQuery;
using DevFreela.Application.Queries.Skills.GetSkillByIdQuery;


namespace DevFreela.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var stringConnection = configuration.GetConnectionString("DevFreelaDB");
            services.AddDbContext<DevFreelaDbContext>(
                options => options.UseSqlServer(stringConnection)
            );
            services.AddMediatR(typeof(CreateProjectCommand));
            services.AddMediatR(typeof(CreateCommentCommand));
            services.AddMediatR(typeof(DeleteProjectCommand));
            services.AddMediatR(typeof(UpdateProjectCommand));

            services.AddMediatR(typeof(GetAllProjectsQuery));
            services.AddMediatR(typeof(GetProjectByIdQuery));
            services.AddMediatR(typeof(GetCommentsByIdProjectQuery));
            services.AddMediatR(typeof(GetAllSkillsQuery));
            services.AddMediatR(typeof(GetSkillByIdQuery));

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
