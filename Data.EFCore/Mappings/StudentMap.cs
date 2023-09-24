using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Mappings
{
    internal class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.HasData(
                new Student(1, "Tahir Can", "Danacı", new DateTime(1999, 10, 15), 1),
                new Student(2, "Akın", "Ertaylan", new DateTime(2001, 10, 15), 2)
            );
        }
    }
}
