using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class addseatnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                schema: "public",
                table: "Seat",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber",
                schema: "public",
                table: "Seat");
        }
    }
}
