using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.DataBase
{
    public partial class InitailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "BuyItem",
                schema: "public",
                columns: table => new
                {
                    BuyItemID = table.Column<string>(nullable: false),
                    OrderID = table.Column<string>(nullable: true),
                    GoodsID = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyItem", x => x.BuyItemID);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                schema: "public",
                columns: table => new
                {
                    GoodsID = table.Column<string>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    QRCode = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    PictureURL = table.Column<string>(nullable: true),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    MinSellingPrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    SoldOut = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "public",
                columns: table => new
                {
                    OrderID = table.Column<string>(nullable: false),
                    SellerID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    SellerOrderIndex = table.Column<int>(nullable: false),
                    Create = table.Column<DateTime>(nullable: false),
                    Payable = table.Column<decimal>(nullable: false),
                    ActPay = table.Column<decimal>(nullable: false),
                    PayOrderID = table.Column<string>(nullable: true),
                    PayType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                schema: "public",
                columns: table => new
                {
                    SellerID = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MapURL = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    OwnerWeixinID = table.Column<string>(nullable: true),
                    OwnerPhone = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerIDNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "public",
                columns: table => new
                {
                    WeixinID = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    JoinIn = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.WeixinID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyItem",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Goods",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Seller",
                schema: "public");

            migrationBuilder.DropTable(
                name: "User",
                schema: "public");
        }
    }
}
