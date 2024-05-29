using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities.Infoes;

namespace SoftServeTestTask.DAL.Configurations.Infoes
{
    internal class StudentInfoesConfiguration : IEntityTypeConfiguration<StudentInfoes>
    {
        public void Configure(EntityTypeBuilder<StudentInfoes> builder)
        {
            builder.ToTable("StudentInfoes");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Age)
                .IsRequired();

            builder.Property(si => si.FirstName)
             .IsRequired()
             .HasMaxLength(32);

            builder.Property(si => si.SecondName)
             .IsRequired()
             .HasMaxLength(32);

            builder.Property(si => si.ThirdName)
             .IsRequired()
             .HasMaxLength(32);

            builder.Property(si => si.Gender)
             .IsRequired()
             .HasMaxLength(16);

            builder.Property(si => si.BirthDate)
                .IsRequired();
        }
    }
}
