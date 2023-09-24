using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(p => p.Id);
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(
                new Course((int)EnumRole.Admin, EnumRole.Admin.ToString()),
                new Course((int)EnumRole.User, EnumRole.User.ToString())
            );
        }
    }
}
