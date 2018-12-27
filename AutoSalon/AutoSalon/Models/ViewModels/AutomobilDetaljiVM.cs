using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels
{
    public class AutomobilDetaljiVM
    {
        public int AutomobilID { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string Boja { get; set; }
        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }
    }
}
