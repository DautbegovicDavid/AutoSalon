using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.KupiAutomobilViewModels
{
    public class RezervisiAutomobilVM
    {
        public int KlijentID { get; set; }
        public int PoslovnicaID { get; set; }
        public List<SelectListItem> poslovnice { get; set; }
        public string nazivPoslovnice { get; set; }
        public int AutomobilID { get; set; }
        public int UposlenikID { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public string komentar { get; set; }
        public decimal Iznos { get; set; }
        public double Popust { get; set; }
      


        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string Boja { get; set; }
        public string Gorivo { get; set; }
        public string Motor { get; set; }
        public string Godiste { get; set; }

        public string SlikaURL { get; set; }

      

    }
}
