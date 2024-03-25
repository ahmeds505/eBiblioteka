using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Biblioteka.Migrations
{
    public partial class aktivacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktivacija",
                table: "KorisnickiNalog",
                type: "bit",
                nullable: false,
                defaultValue: false);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktivacija",
                table: "KorisnickiNalog");

        }
    }
}
