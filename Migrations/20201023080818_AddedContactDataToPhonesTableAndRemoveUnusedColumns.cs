using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneDataWarehouse.Migrations
{
    public partial class AddedContactDataToPhonesTableAndRemoveUnusedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "InternalStorage",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "OS",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ScreenSize",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Phones",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Phones",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Phones",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Phones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Phones");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Phones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Phones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InternalStorage",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OS",
                table: "Phones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ram",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Phones",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ScreenSize",
                table: "Phones",
                type: "DECIMAL(2, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
