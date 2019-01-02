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
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljena su samo slova")]
        public string Gorivo { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9\(\)]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljena su samo slova")]
        public string Transmisija { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljeni format : 4x4, Prednji")]
        public string Pogon { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljeni su samo brojevi")]
        public int Kilovati { get; set; }
        public int KonjskeSnage { get; set; }
        public string VelicinaFelgi { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
                "Dozvoljeni su samo brojevi")]
        public float Tezina { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
             "Dozvoljeni su samo brojevi")]
        public int BrojSjedista { get; set; }
        [RegularExpression(@"^[0-9\\/0-9]$", ErrorMessage = "Format nije validan. " +
             "Dozvoljeni format je : 4/5")]
        public string BrojVrata { get; set; }
        public string Kubikaza { get; set; }
        [RegularExpression(@"^[A-ža-ž]+$", ErrorMessage = "Format nije validan. " +
             "Dozvoljena su samo slova")]
        public string Tip { get; set; }
        [RegularExpression(@"^[A-ža-ž0-9]+$", ErrorMessage = "Format nije validan. " +
          "Dozvoljeni format : Euro 4, Euro 5")]
        public string EmisioniStandard { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
          "Dozvoljeni su samo brojevi")]
        public int BrojBrzina { get; set; }
        [RegularExpression(@"^[0-9\.]+$", ErrorMessage = "Format nije validan. " +
          "Dozvoljeni format : 3.3,5.9")]
        public float Kilometraza { get; set; }
        [RegularExpression(@"^[0-9\.]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljeni format : 12.500 ")]
        public double Cijena { get; set; }
        [RegularExpression(@"^[0-9\.]+$", ErrorMessage = "Format nije validan. " +
       "Dozvoljeni format : 12.500 ")]
        public double CijenaRentanja { get; set; }
    }
}
