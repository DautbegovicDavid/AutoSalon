using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DodatnaOprema",
                columns: table => new
                {
                    DodatnaOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatnaOprema", x => x.DodatnaOpremaID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunID);
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
                name: "Grad",
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
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    ProizvodjacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.ProizvodjacID);
                    table.ForeignKey(
                        name: "FK_Proizvodjac_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
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
                name: "Poslovnica",
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
                    table.PrimaryKey("PK_Poslovnica", x => x.PoslovnicaID);
                    table.ForeignKey(
                        name: "FK_Poslovnica_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobil",
                columns: table => new
                {
                    AutomobilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_Automobil", x => x.AutomobilID);
                    table.ForeignKey(
                        name: "FK_Automobil_Proizvodjac_ProizvodjacID",
                        column: x => x.ProizvodjacID,
                        principalTable: "Proizvodjac",
                        principalColumn: "ProizvodjacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutomobilDetalji",
                columns: table => new
                {
                    AutomobilDetaljiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomobilID = table.Column<int>(nullable: false),
                    BrojBrzina = table.Column<string>(nullable: true),
                    BrojSjedista = table.Column<string>(nullable: true),
                    BrojVrata = table.Column<string>(nullable: true),
                    Cijena = table.Column<string>(nullable: true),
                    CijenaRentanja = table.Column<string>(nullable: true),
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
                    VelicinaFelgi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomobilDetalji", x => x.AutomobilDetaljiID);
                    table.ForeignKey(
                        name: "FK_AutomobilDetalji_Automobil_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobil",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupovina",
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
                    table.PrimaryKey("PK_Kupovina", x => x.KupovinaID);
                    table.ForeignKey(
                        name: "FK_Kupovina_Automobil_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobil",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kupovina_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kupovina_Poslovnica_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnica",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupovina_Racun_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racun",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kupovina_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaRentanja",
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
                    table.PrimaryKey("PK_RezervacijaRentanja", x => x.RezervacijaRentanjaID);
                    table.ForeignKey(
                        name: "FK_RezervacijaRentanja_Automobil_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobil",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaRentanja_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaRentanja_Poslovnica_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnica",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaRentanja_Racun_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racun",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervacijaRentanja_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaTestiranja",
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
                    table.PrimaryKey("PK_RezervacijaTestiranja", x => x.RezervacijaTestiranjaID);
                    table.ForeignKey(
                        name: "FK_RezervacijaTestiranja_Automobil_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobil",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaTestiranja_User_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaTestiranja_Poslovnica_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnica",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaTestiranja_User_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    RezervacijaRentanjaID = table.Column<int>(nullable: false),
                    DatumEvidentiranja = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    ocjena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.RezervacijaRentanjaID);
                    table.ForeignKey(
                        name: "FK_Ocjena_RezervacijaRentanja_RezervacijaRentanjaID",
                        column: x => x.RezervacijaRentanjaID,
                        principalTable: "RezervacijaRentanja",
                        principalColumn: "RezervacijaRentanjaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobil_ProizvodjacID",
                table: "Automobil",
                column: "ProizvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_AutomobilDetalji_AutomobilID",
                table: "AutomobilDetalji",
                column: "AutomobilID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_AutomobilID",
                table: "Kupovina",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_KlijentID",
                table: "Kupovina",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_PoslovnicaID",
                table: "Kupovina",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_RacunID",
                table: "Kupovina",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovina_UposlenikID",
                table: "Kupovina",
                column: "UposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Poslovnica_GradID",
                table: "Poslovnica",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjac_DrzavaID",
                table: "Proizvodjac",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaRentanja_AutomobilID",
                table: "RezervacijaRentanja",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaRentanja_KlijentID",
                table: "RezervacijaRentanja",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaRentanja_PoslovnicaID",
                table: "RezervacijaRentanja",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaRentanja_RacunID",
                table: "RezervacijaRentanja",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaRentanja_UposlenikID",
                table: "RezervacijaRentanja",
                column: "UposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTestiranja_AutomobilID",
                table: "RezervacijaTestiranja",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTestiranja_KlijentID",
                table: "RezervacijaTestiranja",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTestiranja_PoslovnicaID",
                table: "RezervacijaTestiranja",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaTestiranja_UposlenikID",
                table: "RezervacijaTestiranja",
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
                name: "AutomobilDetalji");

            migrationBuilder.DropTable(
                name: "DodatnaOprema");

            migrationBuilder.DropTable(
                name: "Kupovina");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "RezervacijaTestiranja");

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
                name: "RezervacijaRentanja");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Automobil");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Poslovnica");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
