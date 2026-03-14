using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamBuilder.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "GradeID",
                table: "Books",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "ID", "Title" },
                values: new object[,]
                {
                    { 1, "ابتدایی-اول" },
                    { 2, "ابتدایی-دوم" },
                    { 3, "ابتدایی-سوم" },
                    { 4, "ابتدایی-چهارم" },
                    { 5, "ابتدایی-پنجم" },
                    { 6, "ابتدایی-ششم" },
                    { 7, "متوسطه اول-هفتم" },
                    { 8, "متوسطه اول-هشتم" },
                    { 9, "متوسطه اول-نهم" },
                    { 10, "متوسطه دوم-دهم" },
                    { 11, "متوسطه دوم-یازدهم" },
                    { 12, "متوسطه دوم-دوازدهم" },
                    { 13, "دانشگاه" },
                    { 14, "سایر" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GradeID",
                table: "Books",
                column: "GradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Grades_GradeID",
                table: "Books",
                column: "GradeID",
                principalTable: "Grades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Grades_GradeID",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Books_GradeID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GradeID",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Books",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
