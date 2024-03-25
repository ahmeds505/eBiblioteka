using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Biblioteka.Migrations
{
    public partial class iznajmljeneknjigeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIznajmljivanja",
                table: "IznajmljeneKnjige",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumIznajmljivanja",
                table: "IznajmljeneKnjige");
        }
    }
}
