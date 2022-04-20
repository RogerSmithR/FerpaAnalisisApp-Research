using Microsoft.EntityFrameworkCore.Migrations;

namespace FerpaAnalisisApp.Data.Migrations
{
    public partial class Rename_DocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "DocumentType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "DocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "Images");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "DocumentTypeId");
        }
    }
}
