using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.KorisnikViewModels
{
    public class KorisnikIndexVM
    {
        public List<Row> Rows { get; set; }
        public List<SelectListItem> Role { get; set; }
        public int RoleID { get; set; }
        public class Row
        {
            public int KorisnikID { get; set; }
            public string ImePrezime { get; set; }
            public string Grad { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public DateTime DatumRegistracije { get; set; }
            public string TipKorisnika { get; set; }
            public string Email { get;  set; }
            public string KorisnickoIme { get;  set; }
            public string SlikaURL { get;  set; }
        }
    }
}
