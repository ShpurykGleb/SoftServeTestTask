using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.DAL.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Age)
               .IsRequired();

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(s => s.SecondName)
               .IsRequired()
               .HasMaxLength(32);

            builder.Property(s => s.ThirdName)
               .IsRequired()
               .HasMaxLength(32);

            builder.Property(s => s.Gender)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(s => s.GPA)
                .IsRequired()
                .HasColumnType("decimal(4, 2)");

            builder.Property(s => s.Group)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasMany(s => s.Courses)
                .WithMany(c => c.Students);
        }
    }
}
