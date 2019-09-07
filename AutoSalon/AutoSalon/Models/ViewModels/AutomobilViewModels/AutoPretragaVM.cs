using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.AutomobilViewModels
{
    public class AutoPretragaVM
    {
        
            public int? Id { get; set; }
            public int? cijenaOd { get; set; }
            public int? cijenaDo { get; set; }
            public string proizvodjac { get; set; }
            public string model { get; set; }


    }
}
