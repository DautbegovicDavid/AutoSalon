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
        public int AutomobilID { get; set; }
        public string Model { get; set; }
        public int ProizvodjacID { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string Boja { get; set; }
        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }
    }
}
