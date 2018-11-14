using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSalon.Models
{
    public class Grad
    {
        [Key]
        public int GradID { get; set; }
        public int DrzavaID { get; set; }
        [ForeignKey("DrzavaID")]
        public Drzava Drzava { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
    }
}
