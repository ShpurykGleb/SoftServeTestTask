using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.DAL.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Age)
                .IsRequired();

            builder.Property(t => t.ExperienceYears)
              .IsRequired();

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(t => t.SecondName)
               .IsRequired()
               .HasMaxLength(32);

            builder.Property(t => t.ThirdName)
               .IsRequired()
               .HasMaxLength(32);

            builder.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(t => t.AcademicDegree)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasMany(t => t.Courses)
                .WithMany(c => c.Teachers);
        }
    }
}
