using Microsoft.EntityFrameworkCore.Migrations;

namespace e_Biblioteka.Migrations
{
    public partial class iznajmljeneknjige : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropPrimaryKey(
                name: "PK_IznajmljenaKnjiga",
                table: "IznajmljenaKnjiga");

            migrationBuilder.DropColumn(
                name: "ImeClana",
                table: "IznajmljenaKnjiga");

            migrationBuilder.DropColumn(
                name: "NazivKnjige",
                table: "IznajmljenaKnjiga");

            migrationBuilder.RenameTable(
                name: "IznajmljenaKnjiga",
                newName: "IznajmljeneKnjige");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IznajmljeneKnjige",
                table: "IznajmljeneKnjige",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IznajmljeneKnjige_ClanID",
                table: "IznajmljeneKnjige",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_IznajmljeneKnjige_KnjigaID",
                table: "IznajmljeneKnjige",
                column: "KnjigaID");

            migrationBuilder.AddForeignKey(
                name: "FK_IznajmljeneKnjige_Knjiga_KnjigaID",
                table: "IznajmljeneKnjige",
                column: "KnjigaID",
                principalTable: "Knjiga",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IznajmljeneKnjige_KorisnickiNalog_ClanID",
                table: "IznajmljeneKnjige",
                column: "ClanID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IznajmljeneKnjige_Knjiga_KnjigaID",
                table: "IznajmljeneKnjige");

            migrationBuilder.DropForeignKey(
                name: "FK_IznajmljeneKnjige_KorisnickiNalog_ClanID",
                table: "IznajmljeneKnjige");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IznajmljeneKnjige",
                table: "IznajmljeneKnjige");

            migrationBuilder.DropIndex(
                name: "IX_IznajmljeneKnjige_ClanID",
                table: "IznajmljeneKnjige");

            migrationBuilder.DropIndex(
                name: "IX_IznajmljeneKnjige_KnjigaID",
                table: "IznajmljeneKnjige");

            migrationBuilder.RenameTable(
                name: "IznajmljeneKnjige",
                newName: "IznajmljenaKnjiga");

            migrationBuilder.AddColumn<string>(
                name: "ImeClana",
                table: "IznajmljenaKnjiga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazivKnjige",
                table: "IznajmljenaKnjiga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IznajmljenaKnjiga",
                table: "IznajmljenaKnjiga",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MailData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailToId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MailData_KorisnickiNalog_EndUserId",
                        column: x => x.EndUserId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailData_EndUserId",
                table: "MailData",
                column: "EndUserId");
        }
    }
}
