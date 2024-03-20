using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
using DevFreela.Application.Queries.User.GetUserByIdQuery;
using DevFreela.Application.Queries.User.GetUserSkillByIdQuery;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Application.Commands.Users.CreateUser;
using DevFreela.Application.Commands.Projects.StartProject;
using DevFreela.Application.Commands.Projects.FinishProject;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Application.Commands.Users.LoginUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            services.AddMediatR(typeof(StartProjectCommand));
            services.AddMediatR(typeof(FinishProjectCommand));
            services.AddMediatR(typeof(CreateCommentCommand));
            services.AddMediatR(typeof(DeleteProjectCommand));
            services.AddMediatR(typeof(UpdateProjectCommand));

            services.AddMediatR(typeof(GetAllProjectsQuery));
            services.AddMediatR(typeof(GetProjectByIdQuery));
            services.AddMediatR(typeof(GetCommentsByIdProjectQuery));
            services.AddMediatR(typeof(GetAllSkillsQuery));
            services.AddMediatR(typeof(GetSkillByIdQuery));
            services.AddMediatR(typeof(GetUserByIdQuery));
            services.AddMediatR(typeof(GetUserSkillByIdQuery));
            services.AddMediatR(typeof(CreateUserCommand));
            services.AddMediatR(typeof(LoginUserCommand));

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
