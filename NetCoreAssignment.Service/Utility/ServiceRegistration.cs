using AutoMapper;
using NetCoreAssignment.Service.Services;
using NetCoreAssignment.Service.Contracts.Services;
using NetCoreAssignment.DataAccess.Contexts;
using NetCoreAssignment.DataAccess.Repositories;
using NetCoreAssignment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreAssignment.Service.Authorization;
using NetCoreAssignment.Service.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utility
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("AssignmentAPIConnectionString")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITodoService, TodoService>();

            services.AddScoped<IJwtUtils, JwtUtils>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
