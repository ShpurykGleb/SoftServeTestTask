using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftServeTestTask.DAL.Entities.Contacts;

namespace SoftServeTestTask.DAL.Configurations.Contacts
{
    internal class StudentContactsConfiguration : IEntityTypeConfiguration<StudentContacts>
    {
        public void Configure(EntityTypeBuilder<StudentContacts> builder)
        {
            builder.ToTable("StudentContacts");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Email)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(sc => sc.PhoneNumber)
               .IsRequired()
               .HasMaxLength(15);

            builder.Property(sc => sc.Address)
               .IsRequired()
               .HasMaxLength(64);
        }
    }
}
