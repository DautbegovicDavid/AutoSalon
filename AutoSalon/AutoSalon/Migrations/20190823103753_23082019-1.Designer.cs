﻿// <auto-generated />
using AutoSalon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AutoSalon.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190823103753_23082019-1")]
    partial class _230820191
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoSalon.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Adresa");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DatumRegistracije");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("GradID");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SlikaURL");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AutoSalon.Models.Automobil", b =>
                {
                    b.Property<int>("AutomobilID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Boja")
                        .HasMaxLength(20);

                    b.Property<bool>("Dostupan");

                    b.Property<int>("GodinaProizvodnje");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("Novo");

                    b.Property<int>("ProizvodjacID");

                    b.Property<string>("SlikaURL");

                    b.HasKey("AutomobilID");

                    b.HasIndex("ProizvodjacID");

                    b.ToTable("Automobil");
                });

            modelBuilder.Entity("AutoSalon.Models.AutomobilDetalji", b =>
                {
                    b.Property<int>("AutomobilDetaljiID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutomobilID");

                    b.Property<string>("BrojSjedista")
                        .HasMaxLength(5);

                    b.Property<string>("BrojVrata")
                        .HasMaxLength(5);

                    b.Property<decimal>("Cijena");

                    b.Property<decimal?>("CijenaRentanja");

                    b.Property<string>("EmisioniStandard")
                        .HasMaxLength(20);

                    b.Property<string>("Gorivo")
                        .HasMaxLength(20);

                    b.Property<int>("Kilometraza");

                    b.Property<int>("Kilovati");

                    b.Property<int>("KonjskeSnage");

                    b.Property<string>("Kubikaza");

                    b.Property<string>("Pogon")
                        .HasMaxLength(20);

                    b.Property<int>("PoslovnicaID");

                    b.Property<int>("Tezina");

                    b.Property<string>("Tip")
                        .HasMaxLength(20);

                    b.Property<string>("Transmisija")
                        .HasMaxLength(20);

                    b.Property<string>("VelicinaFelgi")
                        .HasMaxLength(20);

                    b.HasKey("AutomobilDetaljiID");

                    b.HasIndex("AutomobilID")
                        .IsUnique();

                    b.HasIndex("PoslovnicaID");

                    b.ToTable("AutomobilDetalji");
                });

            modelBuilder.Entity("Autosalon.Models.DodatnaOprema", b =>
                {
                    b.Property<int>("DodatnaOpremaID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cijena");

                    b.Property<string>("Naziv");

                    b.HasKey("DodatnaOpremaID");

                    b.ToTable("DodatnaOprema");
                });

            modelBuilder.Entity("AutoSalon.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("AutoSalon.Models.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaID");

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("GradID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("AutoSalon.Models.Kupovina", b =>
                {
                    b.Property<int>("KupovinaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutomobilID");

                    b.Property<DateTime>("DatumKupovine");

                    b.Property<double>("Iznos");

                    b.Property<int>("KlijentID");

                    b.Property<string>("Opis");

                    b.Property<int>("PoslovnicaID");

                    b.Property<int>("RacunID");

                    b.Property<int>("UposlenikID");

                    b.HasKey("KupovinaID");

                    b.HasIndex("AutomobilID");

                    b.HasIndex("KlijentID");

                    b.HasIndex("PoslovnicaID");

                    b.HasIndex("RacunID");

                    b.HasIndex("UposlenikID");

                    b.ToTable("Kupovina");
                });

            modelBuilder.Entity("AutoSalon.Models.Notifikacija", b =>
                {
                    b.Property<int>("NotifikacijaID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumKreiranja");

                    b.Property<int>("PosiljaocID");

                    b.Property<int>("PrimalacID");

                    b.Property<string>("Sadrzaj");

                    b.Property<bool>("Status");

                    b.HasKey("NotifikacijaID");

                    b.HasIndex("PosiljaocID");

                    b.HasIndex("PrimalacID");

                    b.ToTable("Notifikacija");
                });

            modelBuilder.Entity("Autosalon.Models.Ocjena", b =>
                {
                    b.Property<int>("RezervacijaRentanjaID");

                    b.Property<DateTime>("DatumEvidentiranja");

                    b.Property<string>("Napomena");

                    b.Property<int>("ocjena");

                    b.HasKey("RezervacijaRentanjaID");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("AutoSalon.Models.Poslovnica", b =>
                {
                    b.Property<int>("PoslovnicaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("GradID");

                    b.Property<string>("KontaktTelefon")
                        .HasMaxLength(50);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("SlikaURL");

                    b.HasKey("PoslovnicaID");

                    b.HasIndex("GradID");

                    b.ToTable("Poslovnica");
                });

            modelBuilder.Entity("AutoSalon.Models.Proizvodjac", b =>
                {
                    b.Property<int>("ProizvodjacID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaID");

                    b.Property<string>("Naziv");

                    b.Property<string>("SlikaURL");

                    b.HasKey("ProizvodjacID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("AutoSalon.Models.Racun", b =>
                {
                    b.Property<int>("RacunID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<decimal>("Iznos");

                    b.HasKey("RacunID");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("Autosalon.Models.RezervacijaKupovina", b =>
                {
                    b.Property<int>("RezervacijaKupovinaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutomobilID");

                    b.Property<DateTime>("DatumKreiranja");

                    b.Property<DateTime>("DatumPreuzimanja");

                    b.Property<int>("KlijentID");

                    b.Property<string>("Komentar");

                    b.Property<int>("PoslovnicaID");

                    b.Property<int>("UposlenikID");

                    b.HasKey("RezervacijaKupovinaID");

                    b.HasIndex("AutomobilID");

                    b.HasIndex("KlijentID");

                    b.HasIndex("PoslovnicaID");

                    b.HasIndex("UposlenikID");

                    b.ToTable("RezervacijaKupovina");
                });

            modelBuilder.Entity("AutoSalon.Models.RezervacijaRentanjaDodatnaOprema", b =>
                {
                    b.Property<int>("RezervacijaRentanjaDodatnaOpremaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DodatnaOpremaID");

                    b.Property<int>("RezervacijaRentanjaID");

                    b.HasKey("RezervacijaRentanjaDodatnaOpremaID");

                    b.HasIndex("DodatnaOpremaID");

                    b.HasIndex("RezervacijaRentanjaID");

                    b.ToTable("RezervacijaRentanjaDodatnaOprema");
                });

            modelBuilder.Entity("Autosalon.Models.RezervacijaRentanje", b =>
                {
                    b.Property<int>("RezervacijaRentanjaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AutomobilID");

                    b.Property<DateTime>("DatumKreiranja");

                    b.Property<decimal>("Iznos");

                    b.Property<int>("KlijentID");

                    b.Property<string>("Opis");

                    b.Property<double>("Popust");

                    b.Property<int>("PoslovnicaID");

                    b.Property<int?>("RacunID");

                    b.Property<DateTime>("RezervacijaDo");

                    b.Property<DateTime>("RezervacijaOd");

                    b.Property<int>("UposlenikID");

                    b.HasKey("RezervacijaRentanjaID");

                    b.HasIndex("AutomobilID");

                    b.HasIndex("KlijentID");

                    b.HasIndex("PoslovnicaID");

                    b.HasIndex("RacunID");

                    b.HasIndex("UposlenikID");

                    b.ToTable("RezervacijaRentanja");
                });

            modelBuilder.Entity("AutoSalon.Models.UposlenikPoslovnica", b =>
                {
                    b.Property<int>("UposlenikPoslovnicaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PoslovnicaID");

                    b.Property<int>("UposlenikID");

                    b.HasKey("UposlenikPoslovnicaID");

                    b.HasIndex("PoslovnicaID");

                    b.HasIndex("UposlenikID");

                    b.ToTable("UposlenikPoslovnica");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleClaimID");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserClaimID");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.Property<int>("RoleId")
                        .HasColumnName("RoleID");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("AutoSalon.Models.ApplicationUser", b =>
                {
                    b.HasOne("AutoSalon.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID");
                });

            modelBuilder.Entity("AutoSalon.Models.Automobil", b =>
                {
                    b.HasOne("AutoSalon.Models.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.AutomobilDetalji", b =>
                {
                    b.HasOne("AutoSalon.Models.Automobil", "Automobil")
                        .WithOne("AutomobilDetalji")
                        .HasForeignKey("AutoSalon.Models.AutomobilDetalji", "AutomobilID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.Poslovnica", "Poslovnica")
                        .WithMany()
                        .HasForeignKey("PoslovnicaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.Grad", b =>
                {
                    b.HasOne("AutoSalon.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.Kupovina", b =>
                {
                    b.HasOne("AutoSalon.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.Poslovnica", "Poslovnica")
                        .WithMany()
                        .HasForeignKey("PoslovnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.Racun", "Racun")
                        .WithMany()
                        .HasForeignKey("RacunID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.Notifikacija", b =>
                {
                    b.HasOne("AutoSalon.Models.ApplicationUser", "Posiljaoc")
                        .WithMany()
                        .HasForeignKey("PosiljaocID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Primalac")
                        .WithMany()
                        .HasForeignKey("PrimalacID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Autosalon.Models.Ocjena", b =>
                {
                    b.HasOne("Autosalon.Models.RezervacijaRentanje", "RezervacijaRentanja")
                        .WithOne("Ocjena")
                        .HasForeignKey("Autosalon.Models.Ocjena", "RezervacijaRentanjaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.Poslovnica", b =>
                {
                    b.HasOne("AutoSalon.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.Proizvodjac", b =>
                {
                    b.HasOne("AutoSalon.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Autosalon.Models.RezervacijaKupovina", b =>
                {
                    b.HasOne("AutoSalon.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.Poslovnica", "Poslovnica")
                        .WithMany()
                        .HasForeignKey("PoslovnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.RezervacijaRentanjaDodatnaOprema", b =>
                {
                    b.HasOne("Autosalon.Models.DodatnaOprema", "DodatnaOprema")
                        .WithMany()
                        .HasForeignKey("DodatnaOpremaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Autosalon.Models.RezervacijaRentanje", "RezervacijaRentanja")
                        .WithMany()
                        .HasForeignKey("RezervacijaRentanjaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Autosalon.Models.RezervacijaRentanje", b =>
                {
                    b.HasOne("AutoSalon.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.Poslovnica", "Poslovnica")
                        .WithMany()
                        .HasForeignKey("PoslovnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.Racun", "Racun")
                        .WithMany()
                        .HasForeignKey("RacunID");

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutoSalon.Models.UposlenikPoslovnica", b =>
                {
                    b.HasOne("AutoSalon.Models.Poslovnica", "Poslovnica")
                        .WithMany()
                        .HasForeignKey("PoslovnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser", "Uposlenik")
                        .WithMany()
                        .HasForeignKey("UposlenikID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AutoSalon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AutoSalon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutoSalon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AutoSalon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
