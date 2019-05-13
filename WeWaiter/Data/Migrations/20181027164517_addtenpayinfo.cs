using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class addtenpayinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayOrderID",
                schema: "public",
                table: "Order",
                newName: "TransactionId");

            migrationBuilder.AddColumn<string>(
                name: "OpenID",
                schema: "public",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenID",
                schema: "public",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                schema: "public",
                table: "Order",
                newName: "PayOrderID");
        }
    }
}
