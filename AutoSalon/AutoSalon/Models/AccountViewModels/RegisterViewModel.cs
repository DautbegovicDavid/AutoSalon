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
        
        [Required(ErrorMessage = "Email je obavezno polje")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [MinLength(6,ErrorMessage ="Lozinka je prekratka")]
        [MaxLength(30,ErrorMessage ="Lozinka je preduga")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [MinLength(2, ErrorMessage = "Ime je prekratko")]
        [MaxLength(50, ErrorMessage = "Ime je predugo")]
        [RegularExpression(@"^[A-Ža-ž\s]+$",ErrorMessage ="Ime smije sadržavati samo slova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [MinLength(2, ErrorMessage = "Prezime je prekratko")]
        [MaxLength(50, ErrorMessage = "Prezime je predugo")]
        [RegularExpression(@"^[A-Ža-ž\s]+$", ErrorMessage = "Prezime smije sadržavati samo slova")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int? GradID { get; set; }
        public string Adresa { get; set; }

    }
}
