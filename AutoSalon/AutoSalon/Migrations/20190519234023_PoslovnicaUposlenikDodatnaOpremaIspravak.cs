using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class PoslovnicaUposlenikDodatnaOpremaIspravak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UposlenikPoslovnica_User_KorisnikID",
                table: "UposlenikPoslovnica");

            migrationBuilder.RenameColumn(
                name: "KorisnikID",
                table: "UposlenikPoslovnica",
                newName: "PoslovnicaID");

            migrationBuilder.RenameIndex(
                name: "IX_UposlenikPoslovnica_KorisnikID",
                table: "UposlenikPoslovnica",
                newName: "IX_UposlenikPoslovnica_PoslovnicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_UposlenikPoslovnica_Poslovnica_PoslovnicaID",
                table: "UposlenikPoslovnica",
                column: "PoslovnicaID",
                principalTable: "Poslovnica",
                principalColumn: "PoslovnicaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UposlenikPoslovnica_Poslovnica_PoslovnicaID",
                table: "UposlenikPoslovnica");

            migrationBuilder.RenameColumn(
                name: "PoslovnicaID",
                table: "UposlenikPoslovnica",
                newName: "KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_UposlenikPoslovnica_PoslovnicaID",
                table: "UposlenikPoslovnica",
                newName: "IX_UposlenikPoslovnica_KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_UposlenikPoslovnica_User_KorisnikID",
                table: "UposlenikPoslovnica",
                column: "KorisnikID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
