using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class goodsname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                schema: "public",
                table: "BuyItem",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "GoodsName",
                schema: "public",
                table: "BuyItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsName",
                schema: "public",
                table: "BuyItem");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                schema: "public",
                table: "BuyItem",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
