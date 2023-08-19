using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomainNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_SubjectLevels_SubjectLevelId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Question_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_StudentExam_StudentExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Skill_SkillId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_SubjectLevels_SubjectLevelId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_AspNetUsers_UserId",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_Exam_ExamId",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_Answers_AnswerId",
                table: "StudentExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_ExamQuestions_ExamQuestionId",
                table: "StudentExamResult");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResult_StudentExam_StudentExamId",
                table: "StudentExamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExamResult",
                table: "StudentExamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExam",
                table: "StudentExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "StudentExamResult",
                newName: "StudentExamResults");

            migrationBuilder.RenameTable(
                name: "StudentExam",
                newName: "StudentExams");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamResult_StudentExamId",
                table: "StudentExamResults",
                newName: "IX_StudentExamResults_StudentExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamResult_ExamQuestionId",
                table: "StudentExamResults",
                newName: "IX_StudentExamResults_ExamQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamResult_AnswerId",
                table: "StudentExamResults",
                newName: "IX_StudentExamResults_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_UserId",
                table: "StudentExams",
                newName: "IX_StudentExams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExams",
                newName: "IX_StudentExams_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_SubjectLevelId",
                table: "Questions",
                newName: "IX_Questions_SubjectLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_SkillId",
                table: "Questions",
                newName: "IX_Questions_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_SubjectLevelId",
                table: "Exams",
                newName: "IX_Exams_SubjectLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExamResults",
                table: "StudentExamResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExams",
                table: "StudentExams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_StudentExams_StudentExamId",
                table: "ExamQuestions",
                column: "StudentExamId",
                principalTable: "StudentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_SubjectLevels_SubjectLevelId",
                table: "Exams",
                column: "SubjectLevelId",
                principalTable: "SubjectLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Skills_SkillId",
                table: "Questions",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SubjectLevels_SubjectLevelId",
                table: "Questions",
                column: "SubjectLevelId",
                principalTable: "SubjectLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResults_Answers_AnswerId",
                table: "StudentExamResults",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResults_ExamQuestions_ExamQuestionId",
                table: "StudentExamResults",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResults_StudentExams_StudentExamId",
                table: "StudentExamResults",
                column: "StudentExamId",
                principalTable: "StudentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_AspNetUsers_UserId",
                table: "StudentExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_Exams_ExamId",
                table: "StudentExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_StudentExams_StudentExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_SubjectLevels_SubjectLevelId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Skills_SkillId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SubjectLevels_SubjectLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResults_Answers_AnswerId",
                table: "StudentExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResults_ExamQuestions_ExamQuestionId",
                table: "StudentExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamResults_StudentExams_StudentExamId",
                table: "StudentExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_AspNetUsers_UserId",
                table: "StudentExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_Exams_ExamId",
                table: "StudentExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExams",
                table: "StudentExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExamResults",
                table: "StudentExamResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "StudentExams",
                newName: "StudentExam");

            migrationBuilder.RenameTable(
                name: "StudentExamResults",
                newName: "StudentExamResult");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExams_UserId",
                table: "StudentExam",
                newName: "IX_StudentExam_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExams_ExamId",
                table: "StudentExam",
                newName: "IX_StudentExam_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamResults_StudentExamId",
                table: "StudentExamResult",
                newName: "IX_StudentExamResult_StudentExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamResults_ExamQuestionId",
                table: "StudentExamResult",
                newName: "IX_StudentExamResult_ExamQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExamResults_AnswerId",
                table: "StudentExamResult",
                newName: "IX_StudentExamResult_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SubjectLevelId",
                table: "Question",
                newName: "IX_Question_SubjectLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SkillId",
                table: "Question",
                newName: "IX_Question_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_SubjectLevelId",
                table: "Exam",
                newName: "IX_Exam_SubjectLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExam",
                table: "StudentExam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExamResult",
                table: "StudentExamResult",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Question_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_SubjectLevels_SubjectLevelId",
                table: "Exam",
                column: "SubjectLevelId",
                principalTable: "SubjectLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Question_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_StudentExam_StudentExamId",
                table: "ExamQuestions",
                column: "StudentExamId",
                principalTable: "StudentExam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Skill_SkillId",
                table: "Question",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_SubjectLevels_SubjectLevelId",
                table: "Question",
                column: "SubjectLevelId",
                principalTable: "SubjectLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_AspNetUsers_UserId",
                table: "StudentExam",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_Exam_ExamId",
                table: "StudentExam",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamResult_Answers_AnswerId",
                table: "StudentExamResult",
                column: "AnswerId",
                principalTable: "Answers",
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
    }
}
