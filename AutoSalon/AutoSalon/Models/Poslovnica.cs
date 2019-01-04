using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSalon.Models
{
    public class Poslovnica
    {
        [Key]
        public int PoslovnicaID { get; set; }
        [Required(ErrorMessage ="Polje je obavezno")]
        [DisplayName("Grad")]
        public int GradID { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }

        [Required]
        [RegularExpression(@"^[A-Ža-ž 0-9]+$",ErrorMessage ="Format nije validan. " +
            "Dozvoljeno je : -Mala i velika slova" +
            "                -Razmaci i brojevi od 0 do 9")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Naziv mora imati više od 5 znakova a manje od 30")]
        public string Naziv { get; set; }

        [RegularExpression(@"^[A-Ža-ž 0-9\.]+$", ErrorMessage = "Format nije validan. " +
            "Dozvoljeno je : -Mala i velika slova" +
            "                -Razmaci i brojevi od 0 do 9")]
        [StringLength(30, ErrorMessage = "Adresa mora imati maksimalno 30 znakova")]
        public string Adresa { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. Dozvoljeno je unositi samo brojeve")]
        [StringLength(30)]
        [DisplayName("Kontakt telefon")]
        public string KontaktTelefon { get; set; }

        public string SlikaURL { get; set; }
    }
}
