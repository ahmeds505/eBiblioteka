using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Biblioteka.Migrations
{
    public partial class rentlogremovejeVracena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JeVracena",
                table: "RENTlog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JeVracena",
                table: "RENTlog",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
