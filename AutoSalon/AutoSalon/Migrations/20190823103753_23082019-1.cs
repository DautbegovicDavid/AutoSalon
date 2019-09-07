using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class _230820191 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaTestiranja_Automobil_AutomobilID",
                table: "RezervacijaTestiranja");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaTestiranja_User_KlijentID",
                table: "RezervacijaTestiranja");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaTestiranja_Poslovnica_PoslovnicaID",
                table: "RezervacijaTestiranja");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaTestiranja_User_UposlenikID",
                table: "RezervacijaTestiranja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RezervacijaTestiranja",
                table: "RezervacijaTestiranja");

            migrationBuilder.RenameTable(
                name: "RezervacijaTestiranja",
                newName: "RezervacijaKupovina");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaTestiranja_UposlenikID",
                table: "RezervacijaKupovina",
                newName: "IX_RezervacijaKupovina_UposlenikID");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaTestiranja_PoslovnicaID",
                table: "RezervacijaKupovina",
                newName: "IX_RezervacijaKupovina_PoslovnicaID");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaTestiranja_KlijentID",
                table: "RezervacijaKupovina",
                newName: "IX_RezervacijaKupovina_KlijentID");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaTestiranja_AutomobilID",
                table: "RezervacijaKupovina",
                newName: "IX_RezervacijaKupovina_AutomobilID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RezervacijaKupovina",
                table: "RezervacijaKupovina",
                column: "RezervacijaKupovinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKupovina_Automobil_AutomobilID",
                table: "RezervacijaKupovina",
                column: "AutomobilID",
                principalTable: "Automobil",
                principalColumn: "AutomobilID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKupovina_User_KlijentID",
                table: "RezervacijaKupovina",
                column: "KlijentID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKupovina_Poslovnica_PoslovnicaID",
                table: "RezervacijaKupovina",
                column: "PoslovnicaID",
                principalTable: "Poslovnica",
                principalColumn: "PoslovnicaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKupovina_User_UposlenikID",
                table: "RezervacijaKupovina",
                column: "UposlenikID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKupovina_Automobil_AutomobilID",
                table: "RezervacijaKupovina");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKupovina_User_KlijentID",
                table: "RezervacijaKupovina");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKupovina_Poslovnica_PoslovnicaID",
                table: "RezervacijaKupovina");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKupovina_User_UposlenikID",
                table: "RezervacijaKupovina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RezervacijaKupovina",
                table: "RezervacijaKupovina");

            migrationBuilder.RenameTable(
                name: "RezervacijaKupovina",
                newName: "RezervacijaTestiranja");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaKupovina_UposlenikID",
                table: "RezervacijaTestiranja",
                newName: "IX_RezervacijaTestiranja_UposlenikID");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaKupovina_PoslovnicaID",
                table: "RezervacijaTestiranja",
                newName: "IX_RezervacijaTestiranja_PoslovnicaID");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaKupovina_KlijentID",
                table: "RezervacijaTestiranja",
                newName: "IX_RezervacijaTestiranja_KlijentID");

            migrationBuilder.RenameIndex(
                name: "IX_RezervacijaKupovina_AutomobilID",
                table: "RezervacijaTestiranja",
                newName: "IX_RezervacijaTestiranja_AutomobilID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RezervacijaTestiranja",
                table: "RezervacijaTestiranja",
                column: "RezervacijaKupovinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaTestiranja_Automobil_AutomobilID",
                table: "RezervacijaTestiranja",
                column: "AutomobilID",
                principalTable: "Automobil",
                principalColumn: "AutomobilID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaTestiranja_User_KlijentID",
                table: "RezervacijaTestiranja",
                column: "KlijentID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaTestiranja_Poslovnica_PoslovnicaID",
                table: "RezervacijaTestiranja",
                column: "PoslovnicaID",
                principalTable: "Poslovnica",
                principalColumn: "PoslovnicaID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaTestiranja_User_UposlenikID",
                table: "RezervacijaTestiranja",
                column: "UposlenikID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
