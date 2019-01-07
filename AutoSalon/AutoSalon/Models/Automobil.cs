
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

        [StringLength(30)]
        [Required]
        public string  Model { get; set; }

        public int ProizvodjacID { get; set; }
        [ForeignKey("ProizvodjacID")]
        public Proizvodjac Proizvodjac { get; set; }

        [Required]
        public int  GodinaProizvodnje { get; set; }

        [StringLength(20)]
        [RegularExpression(@"[A-Ža-ž]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljena su samo slova")]
        public string Boja { get; set; }

        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }
        List<DodatnaOprema> dodatnaOprema = new List<DodatnaOprema>();
        public  AutomobilDetalji AutomobilDetalji { get; set; }


    }
}
