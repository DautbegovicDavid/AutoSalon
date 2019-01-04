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

        [StringLength(20)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljena su samo slova")]
        public string Gorivo { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[A-Za-z0-9\(\)]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljena su samo slova")]
        public string Transmisija { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljeni format : 4x4, Prednji")]
        public string Pogon { get; set; }

      
        public int Kilovati { get; set; }

        public int KonjskeSnage { get; set; }

        [StringLength(20)]
        public string VelicinaFelgi { get; set; }

        
        public int Tezina { get; set; }

        [StringLength(5)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
             "Dozvoljeni su samo brojevi")]
        public string BrojSjedista { get; set; }

        [StringLength(5)]
        [RegularExpression(@"^[0-9\\/0-9]$", ErrorMessage = "Format nije validan. " +
             "Dozvoljeni format je : 4/5")]
        public string BrojVrata { get; set; }

        public float Kubikaza { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[A-ža-ž]+$", ErrorMessage = "Format nije validan. " +
             "Dozvoljena su samo slova")]
        public string Tip { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[A-ža-ž0-9]+$", ErrorMessage = "Format nije validan. " +
          "Dozvoljeni format : Euro 4, Euro 5")]
        public string EmisioniStandard { get; set; }

        
        public int Kilometraza { get; set; }

        [DataType(DataType.Currency)]
        [RegularExpression(@"^[0-9\.]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljeni format : 12.500 ")]
        public double Cijena { get; set; }

        [DataType(DataType.Currency)]
        [RegularExpression(@"^[0-9\.]+$", ErrorMessage = "Format nije validan. " +
       "Dozvoljeni format : 12.500 ")]
        public double CijenaRentanja { get; set; }
    }
}
