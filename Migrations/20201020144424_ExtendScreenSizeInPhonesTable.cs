using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneDataWarehouse.Migrations
{
    public partial class ExtendScreenSizeInPhonesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ScreenSize",
                table: "Phones",
                type: "DECIMAL(4, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(2, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ScreenSize",
                table: "Phones",
                type: "DECIMAL(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(4, 2)");
        }
    }
}
