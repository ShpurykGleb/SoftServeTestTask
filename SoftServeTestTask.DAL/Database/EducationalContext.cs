using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Entities.Contacts;
using SoftServeTestTask.DAL.Entities.Infoes;

namespace SoftServeTestTask.DAL.Database
{
    public class EducationalContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentContacts> StudentContacts { get; set; }
        public DbSet<StudentInfoes> StudentInfoes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherContacts> TeacherContacts { get; set; }
        public DbSet<TeacherInfoes> TeacherInfoes { get; set; }   

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
