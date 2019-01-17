using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.KorisnikViewModels
{
    public class KorisnikDetaljiVM
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [DisplayName("Datum rođenja")]
        public string DatumRodjenja { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        [DisplayName("Kontakt telefon")]
        public string KontaktTelefon { get; set; }
        public string SlikaURL { get; set; }
        [DisplayName("Broj kupovina")]
        public int BrojKupovina { get;  set; }
        [DisplayName("Broj iznajmljivanja")]
        public int BrojIznajmljivanja { get;  set; }
        public string TipKorisnika { get;  set; }
    }
}
