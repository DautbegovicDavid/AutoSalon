using Autosalon.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSalon.Models
{
    public class RezervacijaRentanjaDodatnaOprema
    {
        [Key]
        public int RezervacijaRentanjaDodatnaOpremaID { get; set; }
        public int RezervacijaRentanjaID { get; set; }
        [ForeignKey("RezervacijaRentanjaID")]
        public RezervacijaRentanje RezervacijaRentanja { get; set; }
        public int DodatnaOpremaID { get; set; }
        [ForeignKey("DodatnaOpremaID")]
        public DodatnaOprema DodatnaOprema { get; set; }
        
    }
}
