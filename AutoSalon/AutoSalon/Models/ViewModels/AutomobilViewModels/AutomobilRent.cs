using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.AutomobilViewModels
{
    public class AutomobilRent
    {
        public List<Auto> auta { get; set; }
        public class Auto
        {
            public int AutomobilID { get; set; }
            public int AutomobilDetaljiID { get; set; }

            public string Model { get; set; }
            public string Proizvodjac { get; set; }
            public int GodinaProizvodnje { get; set; }
            public string Boja { get; set; }
            public bool Novo { get; set; }
            public string SlikaURL { get; set; }
            
            public string Gorivo { get; set; }
            public string Transmisija { get; set; }
            public string Pogon { get; set; }
            public int Kilovati { get; set; }
            
            
           
            public string BrojSjedista { get; set; }
            public string BrojVrata { get; set; }
            public string Kubikaza { get; set; }
            public string Tip { get; set; }
            public string EmisioniStandard { get; set; }
            
            public decimal? CijenaRentanja { get; set; }
        }
    }
}
