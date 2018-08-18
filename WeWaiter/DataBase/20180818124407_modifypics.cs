using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class modifypics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pics",
                schema: "public",
                table: "Seller");

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "public",
                columns: table => new
                {
                    FileID = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileExt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Files_Seller_FileID",
                        column: x => x.FileID,
                        principalSchema: "public",
                        principalTable: "Seller",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "public");

            migrationBuilder.AddColumn<List<string>>(
                name: "Pics",
                schema: "public",
                table: "Seller",
                nullable: true);
        }
    }
}
