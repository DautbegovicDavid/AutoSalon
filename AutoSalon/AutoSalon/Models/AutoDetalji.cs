using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.Models
{
    public class AutoDetalji
    {
        [Key]
        [ForeignKey("AutomobilID")]
        public int AutomobilID { get; set; }
        public virtual Automobil Automobil{get;set;}
        public string Gorivo { get; set; }
        public string Transmisija { get; set; }
        public string Pogon { get; set; }
        public string Kilovati { get; set; }
        public string KonjskeSnage { get; set; }
        public string VelicinaFelgi { get; set; }
        public string Tezina { get; set; }
        public string brojSjedista { get; set; }
        public string brojVrata { get; set; }
        public string Kubikaza { get; set; }
        public string Tip { get; set; }
        public string EmisioniStandard { get; set; }
        public string brojBrzina { get; set; }
        public string Kilometraza { get; set; }
        public string Cijena { get; set; }
        public string cijenaRentanja { get; set; }
    }
}
