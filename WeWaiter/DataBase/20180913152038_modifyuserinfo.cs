using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class modifyuserinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                schema: "public",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subscribe",
                schema: "public",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubscribeScene",
                schema: "public",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubscribeTime",
                schema: "public",
                table: "User",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Language",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Province",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Remark",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Sex",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Subscribe",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SubscribeScene",
                schema: "public",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SubscribeTime",
                schema: "public",
                table: "User");
        }
    }
}
