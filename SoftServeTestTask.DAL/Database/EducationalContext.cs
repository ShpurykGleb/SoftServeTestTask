using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.DAL.Database
{
    public class EducationalContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public EducationalContext()
        {

        }

        public EducationalContext(DbContextOptions<EducationalContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationalContext).Assembly);

            modelBuilder.SeedData(_configuration);
        }
    }
}