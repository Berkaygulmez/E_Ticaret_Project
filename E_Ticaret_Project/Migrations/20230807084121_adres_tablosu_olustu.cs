using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret_Project.Migrations
{
    public partial class adres_tablosu_olustu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterAddresses",
                columns: table => new
                {
                    RegisterAddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterAddresses", x => x.RegisterAddressID);
                    table.ForeignKey(
                        name: "FK_RegisterAddresses_Registers_RegisterID",
                        column: x => x.RegisterID,
                        principalTable: "Registers",
                        principalColumn: "RegisterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAddresses_RegisterID",
                table: "RegisterAddresses",
                column: "RegisterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterAddresses");
        }
    }
}
