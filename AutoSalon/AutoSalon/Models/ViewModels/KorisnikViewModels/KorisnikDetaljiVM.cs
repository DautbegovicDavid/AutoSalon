using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.KorisnikViewModels
{
    public class KorisnikDetaljiVM
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string SlikaURL { get; set; }
    }
}
