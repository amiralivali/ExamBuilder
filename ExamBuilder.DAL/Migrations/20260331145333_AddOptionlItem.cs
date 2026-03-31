using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamBuilder.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionlItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option1",
                table: "OptionalQuestions");

            migrationBuilder.DropColumn(
                name: "Option2",
                table: "OptionalQuestions");

            migrationBuilder.DropColumn(
                name: "Option3",
                table: "OptionalQuestions");

            migrationBuilder.DropColumn(
                name: "Option4",
                table: "OptionalQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TrueFalseQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "TrueFalseQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "ShortQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "ShortQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "OptionalQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "OptionalQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "MatchingQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "MatchingQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "FillInBlankQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "FillInBlankQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "DescriptiveQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "DescriptiveQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OptionalItems",
                columns: table => new
                {
                    OptionalID = table.Column<int>(type: "int", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalItems", x => x.OptionalID);
                    table.ForeignKey(
                        name: "FK_OptionalItems_OptionalQuestions_OptionalID",
                        column: x => x.OptionalID,
                        principalTable: "OptionalQuestions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionalItems");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "TrueFalseQuestions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "ShortQuestions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "OptionalQuestions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "MatchingQuestions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "FillInBlankQuestions");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "DescriptiveQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TrueFalseQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "ShortQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "OptionalQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option1",
                table: "OptionalQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Option2",
                table: "OptionalQuestions",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Option3",
                table: "OptionalQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Option4",
                table: "OptionalQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "MatchingQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "FillInBlankQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "DescriptiveQuestions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
