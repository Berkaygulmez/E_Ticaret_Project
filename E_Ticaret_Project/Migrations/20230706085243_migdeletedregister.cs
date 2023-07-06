using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret_Project.Migrations
{
    public partial class migdeletedregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Registers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
