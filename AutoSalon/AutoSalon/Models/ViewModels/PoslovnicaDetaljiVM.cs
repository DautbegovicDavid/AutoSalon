using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels
{
    public class PoslovnicaDetaljiVM
    {
        public int PoslovnicaID { get; set; }
        public string Grad { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string SlikaUrl { get; set; }
    }
}
