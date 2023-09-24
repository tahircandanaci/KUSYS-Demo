using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Mappings
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(p => p.Id);
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(
                new Course(1,"Algoritmalar ve Programlama"),
                new Course(2,"Veri Yapıları"),
                new Course(3,"İşletim Sistemleri"),
                new Course(4,"Görüntü İşleme"),
                new Course(5,"Bilgisayar Mühendisliğine Giriş"),
                new Course(6,"Matematik 1"),
                new Course(7,"Matematik 2"),
                new Course(8,"Fizik 1"),
                new Course(9,"Fizik 2")
            );
        }
    }
}
