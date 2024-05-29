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

            builder.HasOne(t => t.Info)
                  .WithOne()
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Contacts)
                 .WithOne()
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.GPA)
                .IsRequired()
                .HasColumnType("decimal(4, 2)");

            builder.Property(s => s.Group)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasMany(t => t.Courses)
                .WithMany(s => s.Students);
             
        }
    }
}
