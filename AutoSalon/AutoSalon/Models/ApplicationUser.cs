using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AutoSalon.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
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

        public int GradID { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string SlikaURL { get; set; }
    }
}
