using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.BLL.Behaviours;
using SoftServeTestTask.DAL.Database;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.WebApi.Middleware;
using System.Reflection;

namespace SoftServeTestTask.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

            services.AddDbContext<EducationalContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
        }

        public static void AddAutopMapperProfilesFromAssembly(this IServiceCollection services, string assemlyName)
        {
            services.AddAutoMapper(Assembly.Load(assemlyName));
        }

        public static void AddGenericRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void AddGlobalExceptionHandlerMiddleware(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandler>();
        }

        public static void AddValidationBehaviours(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
