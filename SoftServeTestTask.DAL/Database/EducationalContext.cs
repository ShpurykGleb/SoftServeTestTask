using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.DAL.Database
{
    public class EducationalContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public EducationalContext()
        {

        }

        public EducationalContext(DbContextOptions<EducationalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationalContext).Assembly);

            modelBuilder.SeedData();
        }
    }
}