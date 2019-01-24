using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.AutomobilViewModels
{
    public class AutomobilDodajVM
    {
        public List<SelectListItem> Proizvodjaci { get; set; }
        public List<SelectListItem> Goriva { get; set; }
        public List<SelectListItem> Transmisije { get; set; }
        public List<SelectListItem> Pogoni { get; set; }
        public List<SelectListItem> Tipovi { get; set; }
        public List<SelectListItem> EmisioniStandardi { get; set; }
        public List<SelectListItem> BrojeviVrata { get; set; }

        [Required(ErrorMessage = "Model je obavezno polje")]
        [MinLength(2, ErrorMessage = "Unos je prekratak")]
        [MaxLength(30, ErrorMessage = "Unos je predug")]
        [RegularExpression(@"[A-Ža-ž\s0-9]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljeni format : Golf VI,Golf 6")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Proizvođač je obavezno polje")]
        public int ProizvodjacID { get; set; }

        [Required(ErrorMessage = "Godina proizvodnje je obavezno polje")]
        public int GodinaProizvodnje { get; set; }

        [MinLength(4,ErrorMessage ="Unos je prekratak")]
        [MaxLength(20,ErrorMessage ="Unos je predug")]
        [RegularExpression(@"[A-Ža-ž]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljena su samo slova")]
        public string Boja { get; set; }

        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }

        [Required(ErrorMessage = "Vrsta goriva je obavezno polje")]
    
        public string Gorivo { get; set; }

        [Required(ErrorMessage = "Vrsta transmisije je obavezno polje")]
   
        public string Transmisija { get; set; }

        [Required(ErrorMessage = "Tip pogona je obavezno polje")]
   
        public string Pogon { get; set; }

        [Required(ErrorMessage = "Snaga (u kW) je obavezno polje")]
        public int Kilovati { get; set; }

        [MaxLength(20, ErrorMessage = "Unos je predug")]
        [RegularExpression(@"^[0-9xX\s]+$", ErrorMessage = "Format nije validan. " +
           "Dozvoljeni format: 14x14,14 x 14")]
        public string VelicinaFelgi { get; set; }

        [Required(ErrorMessage = "Težina je obavezno polje")]
       
        public int Tezina { get; set; }
        [StringLength(5, ErrorMessage = "Unos je predug")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
           "Dozvoljeni format: 5,7,9")]
        public string BrojSjedista { get; set; }

    
        public string BrojVrata { get; set; }

        [Required(ErrorMessage ="Kubikaža je obavezno polje")]
        [MaxLength(5,ErrorMessage =("Unos je predug"))]
       [RegularExpression(@"^[0-9]+(\.)[0-9]+$", ErrorMessage = "Format nije validan. " +
     "Dozvoljeni format : 2.7,2.9,1.9 ")]
        public string Kubikaza { get; set; }

        [Required(ErrorMessage = "Tip je obavezno polje")]
        public string Tip { get; set; }

        [Required(ErrorMessage = "Emisioni standard je obavezno polje")]
        public string EmisioniStandard { get; set; }

       
        public int Kilometraza { get; set; }

        [Required(ErrorMessage = "Cijena je obavezno polje")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
       "Dozvoljeni format : 12500,10850 ")]
        public decimal Cijena { get; set; }


        [DataType(DataType.Currency)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
       "Dozvoljeni format : 40,55 ")]
        public decimal? CijenaRentanja { get; set; } = 0;
    }
}
