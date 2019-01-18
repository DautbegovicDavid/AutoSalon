using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Korisničko ime")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Lozinka")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }
}
