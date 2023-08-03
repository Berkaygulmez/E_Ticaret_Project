using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret_Project.Migrations
{
    public partial class productImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Registers_RegisterID",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "RegisterID",
                table: "ProductImages",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_RegisterID",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductImages",
                newName: "RegisterID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                newName: "IX_ProductImages_RegisterID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Registers_RegisterID",
                table: "ProductImages",
                column: "RegisterID",
                principalTable: "Registers",
                principalColumn: "RegisterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
