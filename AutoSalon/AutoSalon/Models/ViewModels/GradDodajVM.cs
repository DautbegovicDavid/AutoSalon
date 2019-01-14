using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace AutoSalon.Models.ViewModels
{
    public class GradDodajVM
    {
        public List<SelectListItem> Drzava { get; set; }
        public Grad Grad { get; set; }
    }
}
