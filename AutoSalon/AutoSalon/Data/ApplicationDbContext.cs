using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutoSalon.Models;
using Microsoft.AspNetCore.Identity;
using Autosalon.Models;
using System;

namespace AutoSalon.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {

        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Poslovnica> Poslovnica { get; set; }
        public DbSet<Automobil> Automobil { get; set; }
        public DbSet<AutomobilDetalji> AutomobilDetalji { get; set; }
        public DbSet<DodatnaOprema> DodatnaOprema { get; set; }
        public DbSet<Kupovina> Kupovina { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }

        internal object Find(int x)
        {
            throw new NotImplementedException();
        }

        public DbSet<Racun> Racun { get; set; }
        public DbSet<RezervacijaRentanje> RezervacijaRentanja { get; set; }
        public DbSet<RezervacijaKupovina> RezervacijaKupovina { get; set; }
        public DbSet<Notifikacija> Notifikacija { get; set; }
        public DbSet<RezervacijaRentanjaDodatnaOprema> RezervacijaRentanjaDodatnaOprema { get; set; }
        public DbSet<UposlenikPoslovnica> UposlenikPoslovnica { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Property(e => e.Id).HasColumnName("UserID");

            });

            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.Property(e => e.Id).HasColumnName("RoleID");

            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaim");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.Id).HasColumnName("UserClaimID");

            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogin");
                entity.Property(e => e.UserId).HasColumnName("UserID");

            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaim");
                entity.Property(e => e.Id).HasColumnName("RoleClaimID");
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRole");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

            });


            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserToken");
                entity.Property(e => e.UserId).HasColumnName("UserID");

            });
          


        }
    }
}
