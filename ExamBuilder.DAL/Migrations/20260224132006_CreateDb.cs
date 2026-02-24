using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamBuilder.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LessonCount = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lessons_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptiveQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptiveQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DescriptiveQuestions_DifficultyLevels_DifficultyLevelID",
                        column: x => x.DifficultyLevelID,
                        principalTable: "DifficultyLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptiveQuestions_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatchingQuestions_DifficultyLevels_DifficultyLevelID",
                        column: x => x.DifficultyLevelID,
                        principalTable: "DifficultyLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchingQuestions_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionalQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OptionalQuestion_DifficultyLevels_DifficultyLevelID",
                        column: x => x.DifficultyLevelID,
                        principalTable: "DifficultyLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionalQuestion_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShortQuestions_DifficultyLevels_DifficultyLevelID",
                        column: x => x.DifficultyLevelID,
                        principalTable: "DifficultyLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShortQuestions_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrueFalseQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueFalseQuestions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrueFalseQuestions_DifficultyLevels_DifficultyLevelID",
                        column: x => x.DifficultyLevelID,
                        principalTable: "DifficultyLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrueFalseQuestions_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchingItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchingQuestionID = table.Column<int>(type: "int", nullable: false),
                    LeftText = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RightText = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatchingItems_MatchingQuestions_MatchingQuestionID",
                        column: x => x.MatchingQuestionID,
                        principalTable: "MatchingQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrueFalseItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrueFalseQuestionID = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueFalseItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrueFalseItems_TrueFalseQuestions_TrueFalseQuestionID",
                        column: x => x.TrueFalseQuestionID,
                        principalTable: "TrueFalseQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "ID", "Title" },
                values: new object[,]
                {
                    { 1, "آسان" },
                    { 2, "متوسط" },
                    { 3, "سخت" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptiveQuestions_DifficultyLevelID",
                table: "DescriptiveQuestions",
                column: "DifficultyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptiveQuestions_LessonID",
                table: "DescriptiveQuestions",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_BookID",
                table: "Lessons",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingItems_MatchingQuestionID",
                table: "MatchingItems",
                column: "MatchingQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingQuestions_DifficultyLevelID",
                table: "MatchingQuestions",
                column: "DifficultyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchingQuestions_LessonID",
                table: "MatchingQuestions",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_OptionalQuestion_DifficultyLevelID",
                table: "OptionalQuestion",
                column: "DifficultyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_OptionalQuestion_LessonID",
                table: "OptionalQuestion",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_ShortQuestions_DifficultyLevelID",
                table: "ShortQuestions",
                column: "DifficultyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_ShortQuestions_LessonID",
                table: "ShortQuestions",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseItems_TrueFalseQuestionID",
                table: "TrueFalseItems",
                column: "TrueFalseQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseQuestions_DifficultyLevelID",
                table: "TrueFalseQuestions",
                column: "DifficultyLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseQuestions_LessonID",
                table: "TrueFalseQuestions",
                column: "LessonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptiveQuestions");

            migrationBuilder.DropTable(
                name: "MatchingItems");

            migrationBuilder.DropTable(
                name: "OptionalQuestion");

            migrationBuilder.DropTable(
                name: "ShortQuestions");

            migrationBuilder.DropTable(
                name: "TrueFalseItems");

            migrationBuilder.DropTable(
                name: "MatchingQuestions");

            migrationBuilder.DropTable(
                name: "TrueFalseQuestions");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
