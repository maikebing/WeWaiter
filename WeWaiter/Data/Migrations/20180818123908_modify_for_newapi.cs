using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWaiter.Data.Migrations
{
    public partial class modify_for_newapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "LogoURL",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "MapURL",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "OwnerIDNumber",
                schema: "public",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                schema: "public",
                table: "Seller",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OwnerWeixinID",
                schema: "public",
                table: "Seller",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "OwnerPhone",
                schema: "public",
                table: "Seller",
                newName: "Bulletin");

            migrationBuilder.RenameColumn(
                name: "OwnerName",
                schema: "public",
                table: "Seller",
                newName: "Avatar");

            migrationBuilder.AddColumn<int>(
                name: "FoodScore",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MinPrice",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<List<string>>(
                name: "Pics",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankRate",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellCount",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceScore",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                schema: "public",
                table: "Seller",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodScore",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Pics",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "RankRate",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Score",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "SellCount",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "ServiceScore",
                schema: "public",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                schema: "public",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "Seller",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "Seller",
                newName: "OwnerWeixinID");

            migrationBuilder.RenameColumn(
                name: "Bulletin",
                schema: "public",
                table: "Seller",
                newName: "OwnerPhone");

            migrationBuilder.RenameColumn(
                name: "Avatar",
                schema: "public",
                table: "Seller",
                newName: "OwnerName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoURL",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapURL",
                schema: "public",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerIDNumber",
                schema: "public",
                table: "Seller",
                nullable: true);
        }
    }
}
