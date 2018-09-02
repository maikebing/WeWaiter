using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class AddCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatalogID",
                schema: "public",
                table: "Goods",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catalog",
                schema: "public",
                columns: table => new
                {
                    CatalogID = table.Column<string>(nullable: false),
                    SellerID = table.Column<string>(nullable: true),
                    CatalogName = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.CatalogID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "CatalogID",
                schema: "public",
                table: "Goods");
        }
    }
}
