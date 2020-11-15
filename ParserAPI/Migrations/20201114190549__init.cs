using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParserAPI.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DirectorUserId = table.Column<int>(type: "int", nullable: true),
                    ExecutorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_DirectorUserId",
                        column: x => x.DirectorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_ExecutorUserId",
                        column: x => x.ExecutorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateChanged", "DateCreated", "Name", "Status", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 263, DateTimeKind.Local).AddTicks(9220), "Tom", 0, "Tom" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 266, DateTimeKind.Local).AddTicks(6321), "Alice", 0, "Tom" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 266, DateTimeKind.Local).AddTicks(6453), "Sam", 0, "Tom" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 266, DateTimeKind.Local).AddTicks(6469), "Sam", 2, "Tom" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 266, DateTimeKind.Local).AddTicks(6483), "Sam", 1, "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Content", "DateChanged", "DateCreated", "DirectorUserId", "ExecutorUserId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 271, DateTimeKind.Local).AddTicks(2651), 1, 2, "Создать задачу", 1 },
                    { 22, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(4020), 1, 2, "Создать задачу", 1 },
                    { 21, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(4006), 1, 2, "Создать задачу", 1 },
                    { 20, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3992), 1, 2, "Создать задачу", 1 },
                    { 19, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3978), 1, 2, "Создать задачу", 1 },
                    { 18, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3964), 1, 2, "Создать задачу", 1 },
                    { 17, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3949), 1, 2, "Создать задачу", 1 },
                    { 16, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3934), 1, 2, "Создать задачу", 1 },
                    { 15, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3920), 1, 2, "Создать задачу", 1 },
                    { 14, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3906), 1, 2, "Создать задачу", 1 },
                    { 13, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3892), 1, 2, "Создать задачу", 1 },
                    { 12, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3878), 1, 2, "Создать задачу", 1 },
                    { 11, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3864), 1, 2, "Создать задачу", 1 },
                    { 10, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3850), 1, 2, "Создать задачу", 1 },
                    { 9, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3835), 1, 2, "Создать задачу", 1 },
                    { 8, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3822), 1, 2, "Создать задачу", 1 },
                    { 7, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3808), 1, 2, "Создать задачу", 1 },
                    { 6, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3794), 1, 2, "Создать задачу", 1 },
                    { 5, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3780), 1, 2, "Создать задачу", 1 },
                    { 4, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3764), 1, 2, "Создать задачу", 1 },
                    { 3, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3743), 1, 2, "Создать задачу", 1 },
                    { 2, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(3576), 1, 2, "Создать задачу", 1 },
                    { 23, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(4034), 1, 2, "Создать задачу", 1 },
                    { 24, "Описание", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 14, 22, 5, 42, 274, DateTimeKind.Local).AddTicks(4048), 1, 2, "Создать задачу", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DirectorUserId",
                table: "Tasks",
                column: "DirectorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutorUserId",
                table: "Tasks",
                column: "ExecutorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
