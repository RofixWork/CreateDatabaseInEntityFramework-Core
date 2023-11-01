﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuizzes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrueAndFalseQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    CorrectAnswer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueAndFalseQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrueAndFalseQuizzes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuizzes_CourseId",
                table: "MultipleChoiceQuizzes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueAndFalseQuizzes_CourseId",
                table: "TrueAndFalseQuizzes",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultipleChoiceQuizzes");

            migrationBuilder.DropTable(
                name: "TrueAndFalseQuizzes");
        }
    }
}
