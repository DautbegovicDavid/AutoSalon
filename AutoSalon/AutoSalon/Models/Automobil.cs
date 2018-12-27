
using Autosalon.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoSalon.Models
{
    public class Automobil
    {
        [Key]
        public int AutomobilID { get; set; }
        public string  Model { get; set; }
        public int ProizvodjacID { get; set; }
        [ForeignKey("ProizvodjacID")]
        public Proizvodjac Proizvodjac { get; set; }
        public string  GodinaProizvodnje { get; set; }
        public string Boja { get; set; }
        public bool Novo { get; set; }
        public string Slika { get; set; }
        public bool Dostupan { get; set; }
        List<DodatnaOprema> dodatnaOprema = new List<DodatnaOprema>();
        public  AutomobilDetalji AutomobilDetalji { get; set; }


    }
}
