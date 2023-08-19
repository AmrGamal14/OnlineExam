using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exam_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_ExamQuestions_ExamQuestionId",
                table: "StudentExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_StudentExam_StudentExamId",
                table: "StudentExamResult");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "ExamQuestions",
                newName: "StudentExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_StudentExamId");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Exam",
                newName: "QuestionCount");

            migrationBuilder.RenameColumn(
                name: "Correct",
                table: "Answers",
                newName: "IsCorrect");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SubjectLevels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StudentExamResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StudentExam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Skill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Question",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Levels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExamQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Exam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_StudentExam_StudentExamId",
                table: "ExamQuestions",
                column: "StudentExamId",
                principalTable: "StudentExam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResult_ExamQuestions_ExamQuestionId",
                table: "StudentExamResult",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResult_StudentExam_StudentExamId",
                table: "StudentExamResult",
                column: "StudentExamId",
                principalTable: "StudentExam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_StudentExam_StudentExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_ExamQuestions_ExamQuestionId",
                table: "StudentExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_StudentExam_StudentExamId",
                table: "StudentExamResult");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SubjectLevels");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StudentExamResult");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StudentExam");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "StudentExamId",
                table: "ExamQuestions",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_StudentExamId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_ExamId");

            migrationBuilder.RenameColumn(
                name: "QuestionCount",
                table: "Exam",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "Answers",
                newName: "Correct");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exam_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResult_ExamQuestions_ExamQuestionId",
                table: "StudentExamResult",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResult_StudentExam_StudentExamId",
                table: "StudentExamResult",
                column: "StudentExamId",
                principalTable: "StudentExam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
