using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class modifynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "public",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "SoldOut",
                schema: "public",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "SellerOrderIndex",
                schema: "public",
                table: "Order",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "public",
                table: "Goods",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                schema: "public",
                table: "Goods",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "QRCode",
                schema: "public",
                table: "Goods",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "PictureURL",
                schema: "public",
                table: "Goods",
                newName: "Icon");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string[]>(
                name: "Pics",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintID",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "public",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "public",
                table: "Order",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "Goods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                schema: "public",
                table: "Goods",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Pics",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "PrintID",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                schema: "public",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "public",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "Visible",
                schema: "public",
                table: "Goods");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                schema: "public",
                table: "Order",
                newName: "SellerOrderIndex");

            migrationBuilder.RenameColumn(
                name: "Rating",
                schema: "public",
                table: "Goods",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "Goods",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "public",
                table: "Goods",
                newName: "QRCode");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "public",
                table: "Goods",
                newName: "PictureURL");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "public",
                table: "Goods",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoldOut",
                schema: "public",
                table: "Goods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "public",
                columns: table => new
                {
                    FileID = table.Column<string>(nullable: false),
                    FileExt = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Files_Seller_FileID",
                        column: x => x.FileID,
                        principalSchema: "public",
                        principalTable: "Seller",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
