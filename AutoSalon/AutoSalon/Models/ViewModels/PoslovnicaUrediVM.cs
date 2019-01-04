using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.Models.ViewModels
{
    public class PoslovnicaUrediVM
    {
        public List<SelectListItem> Gradovi { get; set; }
        public int PoslovnicaID { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        public int GradID { get; set; }
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [RegularExpression(@"^[A-Ža-ž 0-9]+$", ErrorMessage = "Format nije validan. " +
            "Dozvoljeno je : -Mala i velika slova" +
            "                -Razmaci i brojevi od 0 do 9")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Naziv mora imati više od 5 znakova a manje od 30")]
        public string Naziv { get; set; }

        [RegularExpression(@"^[A-Ža-ž 0-9\.]+$", ErrorMessage = "Format nije validan. " +
            "Dozvoljeno je : -Mala i velika slova" +
            "                -Razmaci i brojevi od 0 do 9")]
        [StringLength(30, ErrorMessage = "Adresa mora imati maksimalno 30 znakova")]
        public string Adresa { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. Dozvoljeno je unositi samo brojeve")]
        [StringLength(30)]
        public string KontaktTelefon { get; set; }

        public string SlikaURL { get; set; }
    }
}
