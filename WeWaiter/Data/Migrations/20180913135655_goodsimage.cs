using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class goodsimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "public",
                table: "BuyItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "public",
                table: "BuyItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "public",
                table: "BuyItem");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "public",
                table: "BuyItem");
        }
    }
}
