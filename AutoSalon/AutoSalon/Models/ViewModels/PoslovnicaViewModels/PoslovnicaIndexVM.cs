using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Models.ViewModels.PoslovnicaViewModels
{
    public class PoslovnicaIndexVM
    {
        public List<Row> Rows { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> Gradovi { get;  set; }
   
        public class Row
        {
            public int PoslovnicaId { get; set; }
            public string Grad { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public string KontaktTelefon { get; set; }
            public string SlikaUrl { get; set; }
        }
    }
}
