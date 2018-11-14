using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSalon.Models
{
    public class Poslovnica
    {
        [Key]
        public int PoslovnicaID { get; set; }
        public int GradID { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string SlikaURL { get; set; }
    }
}
