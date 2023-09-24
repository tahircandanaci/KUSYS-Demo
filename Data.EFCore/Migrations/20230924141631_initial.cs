using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.EFCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4612), "Algoritmalar ve Programlama" },
                    { 2, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4614), "Veri Yapıları" },
                    { 3, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4615), "İşletim Sistemleri" },
                    { 4, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4616), "Görüntü İşleme" },
                    { 5, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4616), "Bilgisayar Mühendisliğine Giriş" },
                    { 6, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4617), "Matematik 1" },
                    { 7, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4617), "Matematik 2" },
                    { 8, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4618), "Fizik 1" },
                    { 9, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4618), "Fizik 2" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(2757), "Admin" },
                    { 2, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(2767), "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Password", "RoleId", "Username" },
                values: new object[] { 1, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4069), "1234", 2, "tahir.danaci" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Password", "RoleId", "Username" },
                values: new object[] { 2, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4073), "1234", 2, "akin.ertaylan" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Password", "RoleId", "Username" },
                values: new object[] { 3, new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(4073), "1234", 1, "admin" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "BirthDate", "CreateDate", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(5452), "Tahir Can", "Danacı", 1 });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "BirthDate", "CreateDate", "FirstName", "LastName", "UserId" },
                values: new object[] { 2, new DateTime(2001, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 24, 17, 16, 31, 147, DateTimeKind.Local).AddTicks(5455), "Akın", "Ertaylan", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Name",
                table: "Course",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
