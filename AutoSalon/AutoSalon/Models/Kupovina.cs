using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AutoSalon.Models
{
    public class Kupovina
    {
        [Key]
        public int KupovinaID { get; set; }
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

        public int RacunID { get; set; }
        [ForeignKey("RacunID")]

        public Racun Racun { get; set; }


        public DateTime DatumKupovine { get; set; }
        public double Iznos { get; set; }
        public string Opis { get; set; }
    }
}
