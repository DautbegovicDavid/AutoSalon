using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.PoslovnicaViewModels
{
    public class PoslovnicaDetaljiVM
    {
        public int PoslovnicaID { get; set; }
        public string Grad { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        [DisplayName("Kontakt telefon")]
        public string KontaktTelefon { get; set; }
        public string SlikaUrl { get; set; }
    }
}
