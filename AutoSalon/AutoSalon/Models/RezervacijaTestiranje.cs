using AutoSalon.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autosalon.Models
{
    public class RezervacijaTestiranje
    {
        [Key]
        public int RezervacijaTestiranjaID { get; set; }
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

        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumTestiranja { get; set; }

        public string Status { get; set; }// ???

    }
}