using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class _23082019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "RezervacijaTestiranja",
                newName: "Komentar");

            migrationBuilder.RenameColumn(
                name: "DatumTestiranja",
                table: "RezervacijaTestiranja",
                newName: "DatumPreuzimanja");

            migrationBuilder.RenameColumn(
                name: "RezervacijaTestiranjaID",
                table: "RezervacijaTestiranja",
                newName: "RezervacijaKupovinaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Komentar",
                table: "RezervacijaTestiranja",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DatumPreuzimanja",
                table: "RezervacijaTestiranja",
                newName: "DatumTestiranja");

            migrationBuilder.RenameColumn(
                name: "RezervacijaKupovinaID",
                table: "RezervacijaTestiranja",
                newName: "RezervacijaTestiranjaID");
        }
    }
}
