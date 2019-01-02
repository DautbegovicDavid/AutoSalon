using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels
{
    public class AutomobilUrediVM
    {
        public List<SelectListItem> Proizvodjaci { get; set; }
        public List<SelectListItem> Goriva { get; set; }
        public List<SelectListItem> Transmisije { get; set; }
        public List<SelectListItem> Pogoni { get; set; }
        public List<SelectListItem> Tipovi { get; set; }
        public List<SelectListItem> EmisioniStandardi { get; set; }
        public List<SelectListItem> BrojeviVrata { get; set; }


        public int AutomobilID { get; set; }
        public string Model { get; set; }
        public int ProizvodjacID { get; set; }
        public int GodinaProizvodnje { get; set; }
        public string Boja { get; set; }
        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }
        public string Gorivo { get; set; }
        public string Transmisija { get; set; }
        public string Pogon { get; set; }
        public int Kilovati { get; set; }
        public string VelicinaFelgi { get; set; }
        public float Tezina { get; set; }
        public int BrojSjedista { get; set; }
        public string BrojVrata { get; set; }
        public string Kubikaza { get; set; }
        public string Tip { get; set; }
        public string EmisioniStandard { get; set; }
        public float Kilometraza { get; set; }
        public double Cijena { get; set; }
        public double CijenaRentanja { get; set; }
    }
}
