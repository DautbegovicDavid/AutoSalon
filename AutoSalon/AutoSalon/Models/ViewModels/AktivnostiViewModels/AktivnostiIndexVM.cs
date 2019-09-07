using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.AktivnostiViewModels
{
    public class AktivnostiIndexVM
    {
        public string ImePrezime { get; set; }
        public string GradDrzava { get; set; }
        public List<Rentanja> rentanja { get; set; }
        public List<Kupovine> kupovine { get; set; }
        public class Rentanja
        {
            public DateTime datumKreiranja { get; set; }
            public DateTime datumPreuzimanja { get; set; }
            public DateTime datumVracanja { get; set; }
            public string Poslovnica { get; set; }
            public string Uposlenik { get; set; }
            public string Automobil { get; set; }


        }
        public class Kupovine
        {
            public DateTime datumKreiranja { get; set; }
            public DateTime datumPreuzimanja { get; set; }
            public string Poslovnica { get; set; }
            public string Uposlenik { get; set; }
            public string Automobil { get; set; }
            public bool kompletiranaKupovina { get; set; }


        }
    }
}
