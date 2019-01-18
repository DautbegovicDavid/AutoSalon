using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "Lozinka je prekratka")]
        [MaxLength(30, ErrorMessage = "Lozinka je preduga")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda nove lozinke")]
        [Compare("NewPassword", ErrorMessage = "Lozinke se ne podudaraju")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
