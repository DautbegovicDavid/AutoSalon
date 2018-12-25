using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class pocetna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autodetalji",
                columns: table => new
                {
                    AutomobilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<string>(nullable: true),
                    EmisioniStandard = table.Column<string>(nullable: true),
                    Gorivo = table.Column<string>(nullable: true),
                    Kilometraza = table.Column<string>(nullable: true),
                    Kilovati = table.Column<string>(nullable: true),
                    KonjskeSnage = table.Column<string>(nullable: true),
                    Kubikaza = table.Column<string>(nullable: true),
                    Pogon = table.Column<string>(nullable: true),
                    Tezina = table.Column<string>(nullable: true),
                    Tip = table.Column<string>(nullable: true),
                    Transmisija = table.Column<string>(nullable: true),
                    VelicinaFelgi = table.Column<string>(nullable: true),
                    brojBrzina = table.Column<string>(nullable: true),
                    brojSjedista = table.Column<string>(nullable: true),
                    brojVrata = table.Column<string>(nullable: true),
                    cijenaRentanja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autodetalji", x => x.AutomobilID);
                });

            migrationBuilder.CreateTable(
                name: "DodatneOpreme",
                columns: table => new
                {
                    DodatnaOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatneOpreme", x => x.DodatnaOpremaID);
                });

            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Racuni",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuni", x => x.RacunID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Gradovi_Drzave_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjaci",
                columns: table => new
                {
                    ProizvodjacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjaci", x => x.ProizvodjacID);
                    table.ForeignKey(
                        name: "FK_Proizvodjaci_Drzave_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    RoleClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.RoleClaimID);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    UserClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.UserClaimID);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserID, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poslovnice",
                columns: table => new
                {
                    PoslovnicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(maxLength: 30, nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    KontaktTelefon = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false),
                    SlikaURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poslovnice", x => x.PoslovnicaID);
                    table.ForeignKey(
                        name: "FK_Poslovnice_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    AutomobilID = table.Column<int>(nullable: false),
                    Boja = table.Column<string>(nullable: true),
                    Dostupan = table.Column<bool>(nullable: false),
                    GodinaProizvodnje = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Novo = table.Column<bool>(nullable: false),
                    ProizvodjacID = table.Column<int>(nullable: false),
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.AutomobilID);
                    table.ForeignKey(
                        name: "FK_Automobili_Autodetalji_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Autodetalji",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobili_Proizvodjaci_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjaci",
                        principalColumn: "ProizvodjacID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kupovine_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kupovine_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "rezervacijeRentanja",
                columns: table => new
                {
                    RezervacijaRentanjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomobilID = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Popust = table.Column<double>(nullable: false),
                    PoslovnicaID = table.Column<int>(nullable: false),
                    RacunID = table.Column<int>(nullable: true),
                    RezervacijaDo = table.Column<DateTime>(nullable: false),
                    RezervacijaOd = table.Column<DateTime>(nullable: false),
                    UposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacijeRentanja", x => x.RezervacijaRentanjaID);
                    table.ForeignKey(
                        name: "FK_rezervacijeRentanja_Automobili_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobili",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacijeRentanja_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacijeRentanja_Poslovnice_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnice",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_rezervacijeRentanja_Racuni_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racuni",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rezervacijeRentanja_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "rezervacijeTestiranja",
                columns: table => new
                {
                    RezervacijaTestiranjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomobilID = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    DatumTestiranja = table.Column<DateTime>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    PoslovnicaID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacijeTestiranja", x => x.RezervacijaTestiranjaID);
                    table.ForeignKey(
                        name: "FK_rezervacijeTestiranja_Automobili_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobili",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacijeTestiranja_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacijeTestiranja_Poslovnice_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnice",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_rezervacijeTestiranja_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    RezervacijaRentanjaID = table.Column<int>(nullable: false),
                    DatumEvidentiranja = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    ocjena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.RezervacijaRentanjaID);
                    table.ForeignKey(
                        name: "FK_Ocjene_rezervacijeRentanja_RezervacijaRentanjaID",
                        column: x => x.RezervacijaRentanjaID,
                        principalTable: "rezervacijeRentanja",
                        principalColumn: "RezervacijaRentanjaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_ProizvodjacID",
                table: "Automobili",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi_DrzavaID",
                table: "Gradovi",
                column: "DrzavaID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Poslovnice_GradID",
                table: "Poslovnice",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjaci_DrzavaID",
                table: "Proizvodjaci",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeRentanja_AutomobilID",
                table: "rezervacijeRentanja",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeRentanja_KlijentID",
                table: "rezervacijeRentanja",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeRentanja_PoslovnicaID",
                table: "rezervacijeRentanja",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeRentanja_RacunID",
                table: "rezervacijeRentanja",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeRentanja_UposlenikID",
                table: "rezervacijeRentanja",
                column: "UposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeTestiranja_AutomobilID",
                table: "rezervacijeTestiranja",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeTestiranja_KlijentID",
                table: "rezervacijeTestiranja",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeTestiranja_PoslovnicaID",
                table: "rezervacijeTestiranja",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacijeTestiranja_UposlenikID",
                table: "rezervacijeTestiranja",
                column: "UposlenikID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleID",
                table: "RoleClaim",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserID",
                table: "UserClaim",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserID",
                table: "UserLogin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRole",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DodatneOpreme");

            migrationBuilder.DropTable(
                name: "Kupovine");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "rezervacijeTestiranja");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "rezervacijeRentanja");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Automobili");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Poslovnice");

            migrationBuilder.DropTable(
                name: "Racuni");

            migrationBuilder.DropTable(
                name: "Autodetalji");

            migrationBuilder.DropTable(
                name: "Proizvodjaci");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "Drzave");
        }
    }
}
