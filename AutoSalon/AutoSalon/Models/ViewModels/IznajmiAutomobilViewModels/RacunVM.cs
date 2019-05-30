using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.IznajmiAutomobilViewModels
{
    public class RacunVM
    {
        public int RacunID { get; set; }
        public string KlijentImePrezime { get; set; }
        public string KlijentGrad{ get; set; }
        public string KlijentEmail { get; set; }
        public string nazivPoslovnice { get; set; }
        public string adresaPoslovnice { get; set; }
        public string DrzavaGradPoslovnica { get; set; }
        public string Automobil { get; set; }
        public string Uposlenik { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public decimal Iznos { get; set; }
        public double Popust { get; set; }
        public double CijenaOpreme { get; set; }
        public decimal IznosbezOpreme { get; set; }
        public decimal IznosbezPopusta { get; set; }
        public double brojDana { get; set; }
        public string AutomobilDetalji { get; set; }
        public decimal ? cijenaPoDanu{ get; set; }
        public bool Oprema { get; set; }
        public List<string> ListaOpremaNaziv { get; set; }
        public List<string> ListaOpremaCijene { get; set; }






    }
}
