using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class PocetnaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Grad_GradID",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "GradID",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Notifikacija",
                columns: table => new
                {
                    NotifikacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    PosiljaocID = table.Column<int>(nullable: false),
                    PrimalacID = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacija", x => x.NotifikacijaID);
                    table.ForeignKey(
                        name: "FK_Notifikacija_User_PosiljaocID",
                        column: x => x.PosiljaocID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifikacija_User_PrimalacID",
                        column: x => x.PrimalacID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacija_PosiljaocID",
                table: "Notifikacija",
                column: "PosiljaocID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacija_PrimalacID",
                table: "Notifikacija",
                column: "PrimalacID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Grad_GradID",
                table: "User",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Grad_GradID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Notifikacija");

            migrationBuilder.AlterColumn<int>(
                name: "GradID",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Grad_GradID",
                table: "User",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
