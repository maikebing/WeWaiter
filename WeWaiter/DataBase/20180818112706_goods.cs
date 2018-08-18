using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class goods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seller",
                schema: "public",
                table: "Goods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller",
                schema: "public",
                table: "Goods");
        }
    }
}
