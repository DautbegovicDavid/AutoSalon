using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.AutomobilViewModels
{
    public class AutomobilDetaljiVM
    {
        public string div { get; set; }
        public int AutomobilID { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public int GodinaProizvodnje { get; set; }
        public string Boja { get; set; }
        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }
        public string Gorivo { get; set; }
        public string Transmisija { get; set; }
        public string Pogon { get; set; }
        public int Kilovati { get; set; }
        public int KonjskeSnage { get; set; }
        public string VelicinaFelgi { get; set; }
        public int Tezina { get; set; }
        public string BrojSjedista { get; set; }
        public string BrojVrata { get; set; }
        public string Kubikaza { get; set; }
        public string Tip { get; set; }
        public string EmisioniStandard { get; set; }
        public float Kilometraza { get; set; }
        public decimal Cijena { get; set; }
        public decimal? CijenaRentanja { get; set; }
    }
}
