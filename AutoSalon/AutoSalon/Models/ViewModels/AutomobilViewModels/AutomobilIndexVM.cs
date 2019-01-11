using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Models.ViewModels.AutomobilViewModels
{
    public class AutomobilIndexVM
    {
        public List<Row> Rows { get; set; }
        public string nazivModela { get; set; }
        public int ProizvodjacID { get; set; }
        public List<SelectListItem> Proizvodjaci { get;  set; }

        public class Row
        {
            public int AutomobilID { get; set; }
            public string Model { get; set; }          
            public string Proizvodjac { get; set; }
            public int GodinaProizvodnje { get; set; }
            public string Boja { get; set; }
            public string Stanje { get; set; }
            public string SlikaURL { get; set; }
            public bool Dostupan { get; set; }
            public string Cijena { get; set; }
        }
    }
}
