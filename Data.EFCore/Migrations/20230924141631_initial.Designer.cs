﻿// <auto-generated />
using System;
using Data.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.EFCore.Migrations
{
    [DbContext(typeof(KUSYSContext))]
    [Migration("20230924141631_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4612),
                            Name = "Algoritmalar ve Programlama"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4614),
                            Name = "Veri Yapıları"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4615),
                            Name = "İşletim Sistemleri"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4616),
                            Name = "Görüntü İşleme"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4616),
                            Name = "Bilgisayar Mühendisliğine Giriş"
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4617),
                            Name = "Matematik 1"
                        },
                        new
                        {
                            Id = 7,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4617),
                            Name = "Matematik 2"
                        },
                        new
                        {
                            Id = 8,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4618),
                            Name = "Fizik 1"
                        },
                        new
                        {
                            Id = 9,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4618),
                            Name = "Fizik 2"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(2757),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(2767),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(5452),
                            FirstName = "Tahir Can",
                            LastName = "Danacı",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2001, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(5455),
                            FirstName = "Akın",
                            LastName = "Ertaylan",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4069),
                            Password = "1234",
                            RoleId = 2,
                            Username = "tahir.danaci"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4073),
                            Password = "1234",
                            RoleId = 2,
                            Username = "akin.ertaylan"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4073),
                            Password = "1234",
                            RoleId = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.StudentCourse", b =>
                {
                    b.HasOne("Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
