using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.ProizvodjacViewModels
{
    public class ProizvodjacIndexVM
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int ProizvodjacID { get; set; }
            public string Naziv { get; set; }
            public string Drzava { get; set; }
        }
    }
}
