using System;
using System.ComponentModel.DataAnnotations;
namespace AutoSalon.Models
{
    public class Racun
    {
        [Key]
        public int RacunID { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public float Iznos { get; set; }
    }
}
