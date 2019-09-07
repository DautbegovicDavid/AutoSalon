using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSalon.Models.ViewModels.AutomobilViewModels
{
    public class AutomobilKupiVM
    {
        public List<Row> automobili1 { get; set; }
        

        public List<SelectListItem> proizvodjaci { get; set; }
        public int proizvodjacID { get; set; }
        public List<SelectListItem> poslovnice { get; set; }
        public int poslovnicaID { get; set; }
        public List<SelectListItem> modeli { get; set; }


        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string model { get; set; }
        public List<SelectListItem> goriva { get; set; }
        public string gorivo { get; set; }
        public List<SelectListItem> transimisije { get; set; }
        public string transmisija { get; set; }
        public List<SelectListItem> pogoni { get; set; }
        public string pogon { get; set; }


        //[DisplayFormat(ConvertEmptyStringToNull = false)]   
        public List<SelectListItem> emisioniStandardi { get; set; }
        public string emisioniStandard { get; set; }
        public int godisteOd { get; set; }
        public int godisteDo { get; set; }
        public int kilometrazaOd { get; set; }
        public int kilometrazaDo { get; set; }
        public int konjeOd { get; set; }
        public int konjeDo { get; set; }
        public decimal cijenaOd { get; set; }
        public decimal cijenaDo{ get; set; }
        public List<SelectListItem> stanja { get; set; }
        

        public string stanje { get; set; }

        public class Row
        {
            public int AutomobilID { get; set; }
            public string Model { get; set; }
            public string Proizvodjac { get; set; }
            public int GodinaProizvodnje { get; set; }
            public string Boja { get; set; }
            public string Stanje { get; set; }
            public string SlikaURL { get; set; }
            public bool Dostupan { get; set; }
            public string Cijena { get; set; }
        }




    }
}
