using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class PoslovnicaUposlenik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "RezervacijaRentanjaDodatnaOprema");

            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "DodatnaOprema",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "DodatnaOprema");

            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "RezervacijaRentanjaDodatnaOprema",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
