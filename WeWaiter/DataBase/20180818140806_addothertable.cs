using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class addothertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Printer",
                schema: "public",
                columns: table => new
                {
                    PrinterID = table.Column<string>(nullable: false),
                    PrinterType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    ApiURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.PrinterID);
                });

            migrationBuilder.CreateTable(
                name: "SellerInfo",
                schema: "public",
                columns: table => new
                {
                    SellerID = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    MapURL = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    OwnerWeixinID = table.Column<string>(nullable: true),
                    OwnerPhone = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerIDNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerInfo", x => x.SellerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Printer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SellerInfo",
                schema: "public");
        }
    }
}
