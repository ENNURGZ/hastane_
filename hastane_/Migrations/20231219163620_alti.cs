using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hastane_.Migrations
{
    public partial class alti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Users_UserId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_UserId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Poliklinik",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Poliklinik",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "PoliklinikId",
                table: "Randevular",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CalismaSaatiId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PoliklinikId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CalismaSaatleri",
                columns: table => new
                {
                    CalismaSaatiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalismaGunu = table.Column<int>(type: "int", nullable: false),
                    BaslangicSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaSaatleri", x => x.CalismaSaatiId);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PoliklinikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PoliklinikId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikId",
                table: "Randevular",
                column: "PoliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CalismaSaatiId",
                table: "Doctors",
                column: "CalismaSaatiId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PoliklinikId",
                table: "Doctors",
                column: "PoliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_CalismaSaatleri_CalismaSaatiId",
                table: "Doctors",
                column: "CalismaSaatiId",
                principalTable: "CalismaSaatleri",
                principalColumn: "CalismaSaatiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Poliklinikler_PoliklinikId",
                table: "Doctors",
                column: "PoliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "PoliklinikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Poliklinikler_PoliklinikId",
                table: "Randevular",
                column: "PoliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "PoliklinikId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_CalismaSaatleri_CalismaSaatiId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Poliklinikler_PoliklinikId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Poliklinikler_PoliklinikId",
                table: "Randevular");

            migrationBuilder.DropTable(
                name: "CalismaSaatleri");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_PoliklinikId",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CalismaSaatiId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PoliklinikId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PoliklinikId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "CalismaSaatiId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PoliklinikId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Poliklinik",
                table: "Randevular",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Randevular",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Poliklinik",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Doctors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_UserId",
                table: "Randevular",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Users_UserId",
                table: "Randevular",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
