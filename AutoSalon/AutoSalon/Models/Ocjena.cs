using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autosalon.Models
{
    public class Ocjena
    {
        [Key]
        [ForeignKey("RezervacijaRentanja")]
        public virtual int RezervacijaRentanjaID { get; set; }
        public virtual RezervacijaRentanje RezervacijaRentanja { get; set; }

        public DateTime DatumEvidentiranja { get; set; }
        public int ocjena { get; set; }
        public string Napomena { get; set; }
    }
}