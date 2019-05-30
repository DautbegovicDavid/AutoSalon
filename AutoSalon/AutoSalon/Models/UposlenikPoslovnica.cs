using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models
{
    public class UposlenikPoslovnica
    {
        [Key]
        public int UposlenikPoslovnicaID { get; set; }
        public int UposlenikID { get; set; }
        [ForeignKey("UposlenikID")]
        public ApplicationUser Uposlenik { get; set; }
        public int PoslovnicaID { get; set; }
        [ForeignKey("PoslovnicaID")]
        public Poslovnica Poslovnica { get; set; }

    }
}
