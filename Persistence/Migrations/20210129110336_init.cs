using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CourseManager.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartCourse = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndCourse = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timetables_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedOn", "Description", "ModifiedOn", "Name", "Price" },
                values: new object[] { new Guid("8b3e038d-407d-480e-8082-28d79c3bb587"), new DateTime(2021, 1, 29, 11, 3, 36, 427, DateTimeKind.Utc).AddTicks(3225), null, null, "Angular", 215m });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedOn", "Description", "ModifiedOn", "Name", "Price" },
                values: new object[] { new Guid("e75eb48d-0223-4796-adb8-aba89e226772"), new DateTime(2021, 1, 29, 11, 3, 36, 427, DateTimeKind.Utc).AddTicks(3731), null, null, "Asp.net", 26m });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedOn", "Description", "ModifiedOn", "Name", "Price" },
                values: new object[] { new Guid("4fe23cf3-a2db-421d-995c-92d42395e11f"), new DateTime(2021, 1, 29, 11, 3, 36, 427, DateTimeKind.Utc).AddTicks(3736), null, null, "Maya", 28m });

            migrationBuilder.InsertData(
                table: "Timetables",
                columns: new[] { "Id", "CourseId", "CreatedOn", "DayOfWeek", "EndCourse", "ModifiedOn", "StartCourse" },
                values: new object[] { new Guid("f861e2fd-f062-420f-9c29-05e9fc4ec4ee"), new Guid("4fe23cf3-a2db-421d-995c-92d42395e11f"), new DateTime(2021, 1, 29, 11, 3, 36, 433, DateTimeKind.Utc).AddTicks(9847), 3, new TimeSpan(0, 12, 0, 0, 0), null, new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_CourseId",
                table: "Timetables",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}