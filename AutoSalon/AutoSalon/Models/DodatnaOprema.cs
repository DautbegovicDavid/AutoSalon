using System.ComponentModel.DataAnnotations;

namespace Autosalon.Models
    {
        public class DodatnaOprema
        {
            [Key]
            public int DodatnaOpremaID { get; set; }
            public string Naziv { get; set; }

        }
    }


