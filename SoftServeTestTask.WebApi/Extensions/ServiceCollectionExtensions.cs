using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Database;

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
    }
}
