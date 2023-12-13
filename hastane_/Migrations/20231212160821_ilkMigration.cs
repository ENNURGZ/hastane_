using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hastane_.Migrations
{
    public partial class ilkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DoktorSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorID);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    HastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.HastaID);
                    table.ForeignKey(
                        name: "FK_Hastalar_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_DoktorID",
                table: "Hastalar",
                column: "DoktorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Doktorlar");
        }
    }
}
//