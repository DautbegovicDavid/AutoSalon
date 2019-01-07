using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public List<SelectListItem> Gradovi{ get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Ža-ž\s]+$")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Ža-ž\s]+$")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int GradID { get; set; }
        public string Adresa { get; set; }

    }
}
