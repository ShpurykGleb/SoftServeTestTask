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

            builder.HasOne(t => t.Info)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Contacts)
                 .WithOne()
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.AcademicDegree)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(t => t.ExperienceYears)
                .IsRequired();

            builder.HasMany(t => t.Courses)
                .WithMany(c => c.Teachers);
        }
    }
}
