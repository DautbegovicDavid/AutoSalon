using System.Collections.Generic;

namespace AutoSalon.Models.ViewModels
{
    public class DrzavaVM
    {
        public List<Drzave> podaci;
        public int ukupanBrUnesenihGradova;
    }
    public class Drzave
    {
        public int DrzavaID { get; set; }
        public string Naziv { get; set; }
        public int brGradova { get; set; }
    }
}
