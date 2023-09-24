using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(p => p.Id);
            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.HasOne(p => p.Role)
                .WithMany()
                .HasForeignKey(p => p.RoleId);

            builder.HasData(
                new User(1, "tahir.danaci", "1234", (int)EnumRole.User),
                new User(2, "akin.ertaylan", "1234", (int)EnumRole.User),
                new User(3, "admin", "1234", (int)EnumRole.Admin)
            );
        }
    }
}
