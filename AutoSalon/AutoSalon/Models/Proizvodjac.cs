using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoSalon.Models
{
    public class Proizvodjac
    {
        [Key]
        public int ProizvodjacID { get; set; }
        public string Naziv { get; set; }
        public int DrzavaID { get; set; }
        [ForeignKey("DrzavaID")]
        public Drzava Drzava { get; set; }
        public string SlikaURL { get; set; }
    }
}
