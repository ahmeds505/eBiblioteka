using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Biblioteka.Migrations
{
    public partial class rentlogupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JeVracena",
                table: "RENTlog",
                type: "bit",
                nullable: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JeVracena",
                table: "RENTlog");
        }
    }
}
