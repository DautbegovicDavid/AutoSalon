using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class PoslovnicaUposlenikDodatnaOprema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UposlenikPoslovnica",
                columns: table => new
                {
                    UposlenikPoslovnicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikID = table.Column<int>(nullable: false),
                    UposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikPoslovnica", x => x.UposlenikPoslovnicaID);
                    table.ForeignKey(
                        name: "FK_UposlenikPoslovnica_User_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UposlenikPoslovnica_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikPoslovnica_KorisnikID",
                table: "UposlenikPoslovnica",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikPoslovnica_UposlenikID",
                table: "UposlenikPoslovnica",
                column: "UposlenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UposlenikPoslovnica");
        }
    }
}
