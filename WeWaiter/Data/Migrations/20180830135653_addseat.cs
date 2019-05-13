using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class addseat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seat",
                schema: "public",
                columns: table => new
                {
                    SeatId = table.Column<string>(nullable: false),
                    Seller = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    Sit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat",
                schema: "public");
        }
    }
}
