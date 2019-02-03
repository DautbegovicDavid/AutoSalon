using AutoSalon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Autosalon.Models
{
    public class RezervacijaRentanje
    {
        [Key]
        public int RezervacijaRentanjaID { get; set; }

        public int KlijentID { get; set; }
        [ForeignKey("KlijentID")]
        public ApplicationUser Klijent { get; set; }

        public int UposlenikID { get; set; }
        [ForeignKey("UposlenikID")]

        public ApplicationUser Uposlenik { get; set; }

        public int AutomobilID { get; set; }
        [ForeignKey("AutomobilID")]

        public Automobil Automobil { get; set; }

        public int PoslovnicaID { get; set; }
        [ForeignKey("PoslovnicaID")]

        public Poslovnica Poslovnica { get; set; }

        public int? RacunID { get; set; }
        [ForeignKey("RacunID")]

        public Racun Racun { get; set; }


        public DateTime DatumKreiranja { get; set; }
        public DateTime RezervacijaOd { get; set; }
        public DateTime RezervacijaDo { get; set; }
        public decimal Iznos { get; set; }
        public double Popust { get; set; }
        public string Opis { get; set; }

        public virtual Ocjena Ocjena { get; set; }
    }
}