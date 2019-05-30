using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.IznajmiAutomobilViewModels
{
    public class KreirajRezervacijuVM
    {
        public int KlijentID { get; set; }
        public int PoslovnicaID { get; set; }
        public string nazivPoslovnice { get; set; }
        public int AutomobilID { get; set; }
        public int UposlenikID { get; set; }    
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public decimal Iznos { get; set; }
        public double Popust { get; set; }
        public double CijenaOpreme { get; set; }
        public decimal IznosbezOpreme { get; set; }
        public decimal IznosbezPopusta { get; set; }


        public string Model { get; set; }
            public string Proizvodjac { get; set; }
            public string Boja { get; set; }
            public string SlikaURL { get; set; }

        public bool KrovniNosaci { get; set; }
        public bool DjecijaSjedalica { get; set; }
        public bool KrovniKofer { get; set; }
        public bool NosaciSkije { get; set; }
        public bool NosaciBicikla { get; set; }





    }
}
