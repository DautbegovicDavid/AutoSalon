using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoSalon.Models
{
    public class AutomobilDetalji
    {
        [Key]
        public int AutomobilDetaljiID { get; set; }
        public int AutomobilID { get; set; }
        [ForeignKey("AutomobilID")]
        public  Automobil Automobil{get;set;}
        public string Gorivo { get; set; }
        public string Transmisija { get; set; }
        public string Pogon { get; set; }
        public string Kilovati { get; set; }
        public string KonjskeSnage { get; set; }
        public string VelicinaFelgi { get; set; }
        public string Tezina { get; set; }
        public string BrojSjedista { get; set; }
        public string BrojVrata { get; set; }
        public string Kubikaza { get; set; }
        public string Tip { get; set; }
        public string EmisioniStandard { get; set; }
        public string BrojBrzina { get; set; }
        public string Kilometraza { get; set; }
        public string Cijena { get; set; }
        public string CijenaRentanja { get; set; }
    }
}
