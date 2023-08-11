using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret_Project.Migrations
{
    public partial class ProductViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductViewCount",
                table: "Products");
        }
    }
}
