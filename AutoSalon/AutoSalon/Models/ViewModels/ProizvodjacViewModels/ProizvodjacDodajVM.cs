using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.ProizvodjacViewModels
{
    public class ProizvodjacDodajVM
    {
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [MinLength(2, ErrorMessage = "Unos je prekratak")]
        [MaxLength(50, ErrorMessage = "Unos je predug")]
        [RegularExpression(@"[A-Ža-ž\s]+$", ErrorMessage = "Format nije validan. " +
        "Dozvoljeni format : BMW, Audi, Volkswagen")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Država je obavezno polje")]
        public int DrzavaID { get; set; }
        public List<SelectListItem> Drzave { get; set; }
        public string SlikaURL { get; set; }

    }
}
