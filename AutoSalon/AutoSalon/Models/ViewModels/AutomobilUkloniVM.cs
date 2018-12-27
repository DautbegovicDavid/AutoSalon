using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels
{
    public class AutomobilUkloniVM
    {
        public int AutomobilID { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string SlikaURL { get; set; }
    }
}
