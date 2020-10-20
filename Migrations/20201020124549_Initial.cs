using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneDataWarehouse.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ScreenSize = table.Column<decimal>(type: "DECIMAL(2, 2)", nullable: false),
                    Resolution = table.Column<string>(maxLength: 255, nullable: false),
                    Ram = table.Column<int>(nullable: false),
                    InternalStorage = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 255, nullable: false),
                    OS = table.Column<string>(maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    DescriptionUrl = table.Column<string>(maxLength: 255, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
