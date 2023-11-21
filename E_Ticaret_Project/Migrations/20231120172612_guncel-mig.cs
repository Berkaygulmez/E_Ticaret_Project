using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret_Project.Migrations
{
    public partial class guncelmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Registers_RegisterID",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RegisterID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RegisterID",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleID",
                table: "Registers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registers_RolesRoleID",
                table: "Registers",
                column: "RolesRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Roles_RolesRoleID",
                table: "Registers",
                column: "RolesRoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Roles_RolesRoleID",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_RolesRoleID",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "RolesRoleID",
                table: "Registers");

            migrationBuilder.AddColumn<int>(
                name: "RegisterID",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RegisterID",
                table: "Roles",
                column: "RegisterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Registers_RegisterID",
                table: "Roles",
                column: "RegisterID",
                principalTable: "Registers",
                principalColumn: "RegisterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
