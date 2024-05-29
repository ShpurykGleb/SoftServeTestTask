using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities.Contacts;

namespace SoftServeTestTask.DAL.Configurations.Contacts
{
    internal class TeacherContactsConfiguration : IEntityTypeConfiguration<TeacherContacts>
    {
        public void Configure(EntityTypeBuilder<TeacherContacts> builder)
        {
            builder.ToTable("TeacherContacts");

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Email)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(tc => tc.PhoneNumber)
               .IsRequired()
               .HasMaxLength(15);

            builder.Property(tc => tc.Address)
               .IsRequired()
               .HasMaxLength(64);
        }
    }
}
