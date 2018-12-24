using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class dva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupovine",
                columns: table => new
                {
                    KupovinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomobilID = table.Column<int>(nullable: false),
                    DatumKupovine = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    PoslovnicaID = table.Column<int>(nullable: false),
                    RacunID = table.Column<int>(nullable: false),
                    UposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupovine", x => x.KupovinaID);
                    table.ForeignKey(
                        name: "FK_Kupovine_Automobili_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobili",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupovine_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupovine_Poslovnice_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnice",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupovine_Racuni_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racuni",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupovine_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_AutomobilID",
                table: "Kupovine",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_KlijentID",
                table: "Kupovine",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_PoslovnicaID",
                table: "Kupovine",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_RacunID",
                table: "Kupovine",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_UposlenikID",
                table: "Kupovine",
                column: "UposlenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupovine");
        }
    }
}
