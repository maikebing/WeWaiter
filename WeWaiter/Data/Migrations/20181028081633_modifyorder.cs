using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class modifyorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PayDateTime",
                schema: "public",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PrepayId",
                schema: "public",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayDateTime",
                schema: "public",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PrepayId",
                schema: "public",
                table: "Order");
        }
    }
}
