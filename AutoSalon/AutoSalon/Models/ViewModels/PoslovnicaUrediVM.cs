using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AutoSalon.Models.ViewModels
{
    public class PoslovnicaUrediVM
    {
        public List<SelectListItem> Gradovi { get; set; }
        public int PoslovnicaID { get; set; }
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string SlikaUrl { get; set; }
    }
}
