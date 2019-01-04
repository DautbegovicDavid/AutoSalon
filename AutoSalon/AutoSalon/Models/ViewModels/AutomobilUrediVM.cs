using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels
{
    public class AutomobilUrediVM
    {
        public List<SelectListItem> Proizvodjaci { get; set; }
        public List<SelectListItem> Goriva { get; set; }
        public List<SelectListItem> Transmisije { get; set; }
        public List<SelectListItem> Pogoni { get; set; }
        public List<SelectListItem> Tipovi { get; set; }
        public List<SelectListItem> EmisioniStandardi { get; set; }
        public List<SelectListItem> BrojeviVrata { get; set; }


        public int AutomobilID { get; set; }
        [Required(ErrorMessage = "Model je obavezno polje")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Dozvoljeni unos je minimalno 4 karaktera, maksimalno 20 karaktera")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Proizvođač je obavezno polje")]
        public int ProizvodjacID { get; set; }

        [Required(ErrorMessage = "Godina proizvodnje je obavezno polje")]
        [MaxLength(4, ErrorMessage = "Unos je prekratak")]
        public int GodinaProizvodnje { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Dozvoljeni unos je minimalno 4 karaktera, maksimalno 20 karaktera")]
        [RegularExpression(@"[A-Ža-ž]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljena su samo slova")]
        public string Boja { get; set; }

        public bool Novo { get; set; }
        public string SlikaURL { get; set; }
        public bool Dostupan { get; set; }

        [Required(ErrorMessage = "Vrsta goriva je obavezno polje")]
        [StringLength(20, ErrorMessage = "Dozvoljeni unos je maksimalno 20 karaktera")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljena su samo slova")]
        public string Gorivo { get; set; }

        [Required(ErrorMessage = "Vrsta transmisije je obavezno polje")]
        [StringLength(20, ErrorMessage = "Dozvoljeni unos je maksimalno 20 karaktera")]
        [RegularExpression(@"^[A-Za-z0-9\(\)]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljena su samo slova")]
        public string Transmisija { get; set; }

        [Required(ErrorMessage = "Tip pogona je obavezno polje")]
        [StringLength(20, ErrorMessage = "Dozvoljeni unos je maksimalno 20 karaktera")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Format nije validan. " +
         "Dozvoljeni format : 4x4, Prednji")]
        public string Pogon { get; set; }

        [Required(ErrorMessage = "Snaga (u kW) je obavezno polje")]
        public int Kilovati { get; set; }
        public int KonjskeSnage { get; set; }

        [StringLength(20, ErrorMessage = "Dozvoljeni unos je maksimalno 20 karaktera")]
        public string VelicinaFelgi { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format nije validan. " +
                "Dozvoljeni su samo brojevi")]
        public int Tezina { get; set; }


        public string BrojSjedista { get; set; }

        [StringLength(5)]
        [RegularExpression(@"^[0-9\\/0-9]$", ErrorMessage = "Format nije validan. " +
             "Dozvoljeni format je : 4/5")]
        public string BrojVrata { get; set; }

        [RegularExpression(@"^[0-9]+(\.)?[0-9]+$", ErrorMessage = "Format nije validan. " +
            "Dozvoljeni format: 2.7, 3.5")]
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


        [Required(ErrorMessage = "Cijena je obavezno polje")]
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
