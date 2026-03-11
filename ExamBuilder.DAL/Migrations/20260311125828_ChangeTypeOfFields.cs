using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamBuilder.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeOfFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionalQuestion_DifficultyLevels_DifficultyLevelID",
                table: "OptionalQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalQuestion_Lessons_LessonID",
                table: "OptionalQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionalQuestion",
                table: "OptionalQuestion");

            migrationBuilder.RenameTable(
                name: "OptionalQuestion",
                newName: "OptionalQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalQuestion_LessonID",
                table: "OptionalQuestions",
                newName: "IX_OptionalQuestions_LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalQuestion_DifficultyLevelID",
                table: "OptionalQuestions",
                newName: "IX_OptionalQuestions_DifficultyLevelID");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TrueFalseQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "ShortQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "MatchingQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lessons",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "DescriptiveQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "OptionalQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Option4",
                table: "OptionalQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Option3",
                table: "OptionalQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Option2",
                table: "OptionalQuestions",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Option1",
                table: "OptionalQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionalQuestions",
                table: "OptionalQuestions",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "FillInBlankQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillInBlankQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FillInBlankQuestions_DifficultyLevels_DifficultyLevelID",
                        column: x => x.DifficultyLevelID,
                        principalTable: "DifficultyLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FillInBlankQuestions_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillInBlankItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FillInBlankQuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillInBlankItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FillInBlankItems_FillInBlankQuestions_FillInBlankQuestionID",
                        column: x => x.FillInBlankQuestionID,
                        principalTable: "FillInBlankQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillInBlankItems_FillInBlankQuestionID",
                table: "FillInBlankItems",
                column: "FillInBlankQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_FillInBlankQuestions_DifficultyLevelID",
                table: "FillInBlankQuestions",
                column: "DifficultyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_FillInBlankQuestions_LessonID",
                table: "FillInBlankQuestions",
                column: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalQuestions_DifficultyLevels_DifficultyLevelID",
                table: "OptionalQuestions",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalQuestions_Lessons_LessonID",
                table: "OptionalQuestions",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionalQuestions_DifficultyLevels_DifficultyLevelID",
                table: "OptionalQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalQuestions_Lessons_LessonID",
                table: "OptionalQuestions");

            migrationBuilder.DropTable(
                name: "FillInBlankItems");

            migrationBuilder.DropTable(
                name: "FillInBlankQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionalQuestions",
                table: "OptionalQuestions");

            migrationBuilder.RenameTable(
                name: "OptionalQuestions",
                newName: "OptionalQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalQuestions_LessonID",
                table: "OptionalQuestion",
                newName: "IX_OptionalQuestion_LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalQuestions_DifficultyLevelID",
                table: "OptionalQuestion",
                newName: "IX_OptionalQuestion_DifficultyLevelID");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TrueFalseQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "ShortQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "MatchingQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Lessons",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "DescriptiveQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "OptionalQuestion",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Option4",
                table: "OptionalQuestion",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Option3",
                table: "OptionalQuestion",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Option2",
                table: "OptionalQuestion",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<string>(
                name: "Option1",
                table: "OptionalQuestion",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionalQuestion",
                table: "OptionalQuestion",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalQuestion_DifficultyLevels_DifficultyLevelID",
                table: "OptionalQuestion",
                column: "DifficultyLevelID",
                principalTable: "DifficultyLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalQuestion_Lessons_LessonID",
                table: "OptionalQuestion",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
