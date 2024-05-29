using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities.Infoes;

namespace SoftServeTestTask.DAL.Configurations.Infoes
{
    public class TeacherInfoesConfiguration : IEntityTypeConfiguration<TeacherInfoes>
    {
        public void Configure(EntityTypeBuilder<TeacherInfoes> builder)
        {
            builder.ToTable("TeachersInfoes");

            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Age)
                .IsRequired();

            builder.Property(ti => ti.FirstName)
             .IsRequired()
             .HasMaxLength(32);

            builder.Property(ti => ti.SecondName)
             .IsRequired()
             .HasMaxLength(32);

            builder.Property(ti => ti.ThirdName)
             .IsRequired()
             .HasMaxLength(32);

            builder.Property(ti => ti.Gender)
             .IsRequired()
             .HasMaxLength(16);

            builder.Property(ti => ti.BirthDate)
                .IsRequired();
        }
    }
}
