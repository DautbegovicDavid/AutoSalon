using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models
{
    public class Notifikacija
    {
        public int NotifikacijaID { get; set; }
        public int PosiljaocID { get; set; }
        [ForeignKey("PosiljaocID")]
        public ApplicationUser Posiljaoc { get; set; }
        public int PrimalacID { get; set; }
        [ForeignKey("PrimalacID")]
        public ApplicationUser Primalac { get; set; }
        public DateTime DatumKreiranja { get; set; }
        //Da li je notifikacija pročitana
        public bool Status { get; set; }
        public string Sadrzaj { get; set; }

    }
}
