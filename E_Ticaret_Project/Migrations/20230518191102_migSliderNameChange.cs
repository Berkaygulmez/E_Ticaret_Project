using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret_Project.Migrations
{
    public partial class migSliderNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderPhoto",
                table: "HomeSliders");

            migrationBuilder.AddColumn<string>(
                name: "SliderPhotoName",
                table: "HomeSliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderPhotoName",
                table: "HomeSliders");

            migrationBuilder.AddColumn<byte[]>(
                name: "SliderPhoto",
                table: "HomeSliders",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
