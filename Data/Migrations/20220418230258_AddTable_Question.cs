using Microsoft.EntityFrameworkCore.Migrations;

namespace FerpaAnalisisApp.Data.Migrations
{
    public partial class AddTable_Question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDescription = table.Column<string>(nullable: false),
                    Answers = table.Column<string>(nullable: false),
                    CorrectAnswerNumber = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Question_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_DocumentTypeId",
                table: "Question",
                column: "DocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
