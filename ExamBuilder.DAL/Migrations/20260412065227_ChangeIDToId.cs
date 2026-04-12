using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamBuilder.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIDToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Grades_GradeID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptiveQuestions_DifficultyLevels_DifficultyLevelID",
                table: "DescriptiveQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_FillInBlankItems_FillInBlankQuestions_FillInBlankQuestionID",
                table: "FillInBlankItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FillInBlankQuestions_DifficultyLevels_DifficultyLevelID",
                table: "FillInBlankQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Books_BookID",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchingItems_MatchingQuestions_MatchingQuestionID",
                table: "MatchingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchingQuestions_DifficultyLevels_DifficultyLevelID",
                table: "MatchingQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalItems_OptionalQuestions_OptionalID",
                table: "OptionalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalQuestions_DifficultyLevels_DifficultyLevelID",
                table: "OptionalQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortQuestions_DifficultyLevels_DifficultyLevelID",
                table: "ShortQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseItems_TrueFalseQuestions_TrueFalseQuestionID",
                table: "TrueFalseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseQuestions_DifficultyLevels_DifficultyLevelID",
                table: "TrueFalseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseQuestions_Lessons_LessonID",
                table: "TrueFalseQuestions");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "TrueFalseQuestions",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelID",
                table: "TrueFalseQuestions",
                newName: "DifficultyLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_TrueFalseQuestions_LessonID",
                table: "TrueFalseQuestions",
                newName: "IX_TrueFalseQuestions_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_TrueFalseQuestions_DifficultyLevelID",
                table: "TrueFalseQuestions",
                newName: "IX_TrueFalseQuestions_DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "TrueFalseQuestionID",
                table: "TrueFalseItems",
                newName: "TrueFalseQuestionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TrueFalseItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrueFalseItems_TrueFalseQuestionID",
                table: "TrueFalseItems",
                newName: "IX_TrueFalseItems_TrueFalseQuestionId");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelID",
                table: "ShortQuestions",
                newName: "DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ShortQuestions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ShortQuestions_DifficultyLevelID",
                table: "ShortQuestions",
                newName: "IX_ShortQuestions_DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelID",
                table: "OptionalQuestions",
                newName: "DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OptionalQuestions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalQuestions_DifficultyLevelID",
                table: "OptionalQuestions",
                newName: "IX_OptionalQuestions_DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "OptionalID",
                table: "OptionalItems",
                newName: "OptionalId");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelID",
                table: "MatchingQuestions",
                newName: "DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MatchingQuestions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MatchingQuestions_DifficultyLevelID",
                table: "MatchingQuestions",
                newName: "IX_MatchingQuestions_DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "MatchingQuestionID",
                table: "MatchingItems",
                newName: "MatchingQuestionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MatchingItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MatchingItems_MatchingQuestionID",
                table: "MatchingItems",
                newName: "IX_MatchingItems_MatchingQuestionId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Lessons",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Lessons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_BookID",
                table: "Lessons",
                newName: "IX_Lessons_BookId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Grades",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelID",
                table: "FillInBlankQuestions",
                newName: "DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "FillInBlankQuestions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_FillInBlankQuestions_DifficultyLevelID",
                table: "FillInBlankQuestions",
                newName: "IX_FillInBlankQuestions_DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "FillInBlankQuestionID",
                table: "FillInBlankItems",
                newName: "FillInBlankQuestionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "FillInBlankItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_FillInBlankItems_FillInBlankQuestionID",
                table: "FillInBlankItems",
                newName: "IX_FillInBlankItems_FillInBlankQuestionId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExceptionLogs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DifficultyLevels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelID",
                table: "DescriptiveQuestions",
                newName: "DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DescriptiveQuestions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptiveQuestions_DifficultyLevelID",
                table: "DescriptiveQuestions",
                newName: "IX_DescriptiveQuestions_DifficultyLevelId");

            migrationBuilder.RenameColumn(
                name: "GradeID",
                table: "Books",
                newName: "GradeId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GradeID",
                table: "Books",
                newName: "IX_Books_GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Grades_GradeId",
                table: "Books",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptiveQuestions_DifficultyLevels_DifficultyLevelId",
                table: "DescriptiveQuestions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FillInBlankItems_FillInBlankQuestions_FillInBlankQuestionId",
                table: "FillInBlankItems",
                column: "FillInBlankQuestionId",
                principalTable: "FillInBlankQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FillInBlankQuestions_DifficultyLevels_DifficultyLevelId",
                table: "FillInBlankQuestions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Books_BookId",
                table: "Lessons",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchingItems_MatchingQuestions_MatchingQuestionId",
                table: "MatchingItems",
                column: "MatchingQuestionId",
                principalTable: "MatchingQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchingQuestions_DifficultyLevels_DifficultyLevelId",
                table: "MatchingQuestions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalItems_OptionalQuestions_OptionalId",
                table: "OptionalItems",
                column: "OptionalId",
                principalTable: "OptionalQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalQuestions_DifficultyLevels_DifficultyLevelId",
                table: "OptionalQuestions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortQuestions_DifficultyLevels_DifficultyLevelId",
                table: "ShortQuestions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseItems_TrueFalseQuestions_TrueFalseQuestionId",
                table: "TrueFalseItems",
                column: "TrueFalseQuestionId",
                principalTable: "TrueFalseQuestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseQuestions_DifficultyLevels_DifficultyLevelId",
                table: "TrueFalseQuestions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseQuestions_Lessons_LessonId",
                table: "TrueFalseQuestions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Grades_GradeId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptiveQuestions_DifficultyLevels_DifficultyLevelId",
                table: "DescriptiveQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_FillInBlankItems_FillInBlankQuestions_FillInBlankQuestionId",
                table: "FillInBlankItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FillInBlankQuestions_DifficultyLevels_DifficultyLevelId",
                table: "FillInBlankQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Books_BookId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchingItems_MatchingQuestions_MatchingQuestionId",
                table: "MatchingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchingQuestions_DifficultyLevels_DifficultyLevelId",
                table: "MatchingQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalItems_OptionalQuestions_OptionalId",
                table: "OptionalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalQuestions_DifficultyLevels_DifficultyLevelId",
                table: "OptionalQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ShortQuestions_DifficultyLevels_DifficultyLevelId",
                table: "ShortQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseItems_TrueFalseQuestions_TrueFalseQuestionId",
                table: "TrueFalseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseQuestions_DifficultyLevels_DifficultyLevelId",
                table: "TrueFalseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseQuestions_Lessons_LessonId",
                table: "TrueFalseQuestions");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "TrueFalseQuestions",
                newName: "LessonID");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelId",
                table: "TrueFalseQuestions",
                newName: "DifficultyLevelID");

            migrationBuilder.RenameIndex(
                name: "IX_TrueFalseQuestions_LessonId",
                table: "TrueFalseQuestions",
                newName: "IX_TrueFalseQuestions_LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_TrueFalseQuestions_DifficultyLevelId",
                table: "TrueFalseQuestions",
                newName: "IX_TrueFalseQuestions_DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "TrueFalseQuestionId",
                table: "TrueFalseItems",
                newName: "TrueFalseQuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TrueFalseItems",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_TrueFalseItems_TrueFalseQuestionId",
                table: "TrueFalseItems",
                newName: "IX_TrueFalseItems_TrueFalseQuestionID");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelId",
                table: "ShortQuestions",
                newName: "DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShortQuestions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ShortQuestions_DifficultyLevelId",
                table: "ShortQuestions",
                newName: "IX_ShortQuestions_DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelId",
                table: "OptionalQuestions",
                newName: "DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OptionalQuestions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalQuestions_DifficultyLevelId",
                table: "OptionalQuestions",
                newName: "IX_OptionalQuestions_DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "OptionalId",
                table: "OptionalItems",
                newName: "OptionalID");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelId",
                table: "MatchingQuestions",
                newName: "DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MatchingQuestions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_MatchingQuestions_DifficultyLevelId",
                table: "MatchingQuestions",
                newName: "IX_MatchingQuestions_DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "MatchingQuestionId",
                table: "MatchingItems",
                newName: "MatchingQuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MatchingItems",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_MatchingItems_MatchingQuestionId",
                table: "MatchingItems",
                newName: "IX_MatchingItems_MatchingQuestionID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Lessons",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessons",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_BookId",
                table: "Lessons",
                newName: "IX_Lessons_BookID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grades",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelId",
                table: "FillInBlankQuestions",
                newName: "DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FillInBlankQuestions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_FillInBlankQuestions_DifficultyLevelId",
                table: "FillInBlankQuestions",
                newName: "IX_FillInBlankQuestions_DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "FillInBlankQuestionId",
                table: "FillInBlankItems",
                newName: "FillInBlankQuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FillInBlankItems",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_FillInBlankItems_FillInBlankQuestionId",
                table: "FillInBlankItems",
                newName: "IX_FillInBlankItems_FillInBlankQuestionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExceptionLogs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DifficultyLevels",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevelId",
                table: "DescriptiveQuestions",
                newName: "DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DescriptiveQuestions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptiveQuestions_DifficultyLevelId",
                table: "DescriptiveQuestions",
                newName: "IX_DescriptiveQuestions_DifficultyLevelID");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Books",
                newName: "GradeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GradeId",
                table: "Books",
                newName: "IX_Books_GradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Grades_GradeID",
                table: "Books",
                column: "GradeID",
                principalTable: "Grades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptiveQuestions_DifficultyLevels_DifficultyLevelID",
                table: "DescriptiveQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FillInBlankItems_FillInBlankQuestions_FillInBlankQuestionID",
                table: "FillInBlankItems",
                column: "FillInBlankQuestionID",
                principalTable: "FillInBlankQuestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FillInBlankQuestions_DifficultyLevels_DifficultyLevelID",
                table: "FillInBlankQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Books_BookID",
                table: "Lessons",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchingItems_MatchingQuestions_MatchingQuestionID",
                table: "MatchingItems",
                column: "MatchingQuestionID",
                principalTable: "MatchingQuestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchingQuestions_DifficultyLevels_DifficultyLevelID",
                table: "MatchingQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalItems_OptionalQuestions_OptionalID",
                table: "OptionalItems",
                column: "OptionalID",
                principalTable: "OptionalQuestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalQuestions_DifficultyLevels_DifficultyLevelID",
                table: "OptionalQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShortQuestions_DifficultyLevels_DifficultyLevelID",
                table: "ShortQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseItems_TrueFalseQuestions_TrueFalseQuestionID",
                table: "TrueFalseItems",
                column: "TrueFalseQuestionID",
                principalTable: "TrueFalseQuestions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseQuestions_DifficultyLevels_DifficultyLevelID",
                table: "TrueFalseQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseQuestions_Lessons_LessonID",
                table: "TrueFalseQuestions",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
