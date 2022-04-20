using Microsoft.EntityFrameworkCore.Migrations;

namespace FerpaAnalisisApp.Data.Migrations
{
    public partial class AddTable_StatisticDocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatisticDocumentType",
                columns: table => new
                {
                    StatisticDocumentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    TotalCorrect = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticDocumentType", x => x.StatisticDocumentTypeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatisticDocumentType");
        }
    }
}
