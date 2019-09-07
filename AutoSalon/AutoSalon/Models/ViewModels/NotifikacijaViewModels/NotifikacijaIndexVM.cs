using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.NotifikacijaViewModels
{
    public class NotifikacijaIndexVM
    {
        public int KorisnikID { get; set; }
        public bool Klijent { get; set; } 

        public List<Row> Rows { get; set; }

        public class Row
        {
            public int NotifikacijaID { get; set; }
            public string Posiljaoc { get; set; }
            public DateTime DatumKreiranja { get; set; }
            public bool Status { get; set; }
            public string Sadrzaj { get; set; }
        }
    }
}
