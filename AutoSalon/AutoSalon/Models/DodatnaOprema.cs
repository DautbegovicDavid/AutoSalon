using AutoSalon.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autosalon.Models
    {
        public class DodatnaOprema
        {
            [Key]
            public int DodatnaOpremaID { get; set; }
            public string Naziv { get; set; }
            public double Cijena { get; set; }



    }
}


