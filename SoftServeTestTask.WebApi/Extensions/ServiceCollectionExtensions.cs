using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoftServeTestTask.BLL.Behaviours;
using SoftServeTestTask.BLL.Services.Authentication;
using SoftServeTestTask.DAL.Database;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;
using SoftServeTestTask.WebApi.Middleware;
using System.Reflection;
using System.Text;

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

        public static void AddProgramServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EducationalContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });
        }
    }
}
