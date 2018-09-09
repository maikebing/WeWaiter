using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class weixinzhifu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeixinID",
                schema: "public",
                table: "User",
                newName: "UserID");

            migrationBuilder.AddColumn<string>(
                name: "OpenID",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionId",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeatID",
                schema: "public",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                schema: "public",
                table: "Order",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenID",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UnionId",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SeatID",
                schema: "public",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                schema: "public",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "public",
                table: "User",
                newName: "WeixinID");
        }
    }
}
