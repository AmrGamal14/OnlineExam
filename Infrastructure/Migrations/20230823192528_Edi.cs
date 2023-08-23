using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResults_ExamQuestions_ExamQuestionId",
                table: "StudentExamResults");

            migrationBuilder.DropIndex(
                name: "IX_StudentExamResults_ExamQuestionId",
                table: "StudentExamResults");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "StudentExamResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExamQuestionId",
                table: "StudentExamResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamResults_ExamQuestionId",
                table: "StudentExamResults",
                column: "ExamQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResults_ExamQuestions_ExamQuestionId",
                table: "StudentExamResults",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
