using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.DAL.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(c => c.Name)
                .HasMaxLength(32);

            builder.Property(c => c.Description)
                .HasMaxLength(256);

            builder.HasMany(c => c.Students)
                .WithMany(s => s.Courses);

            builder.HasMany(c => c.Teachers)
              .WithMany(t => t.Courses);
        }
    }
}
