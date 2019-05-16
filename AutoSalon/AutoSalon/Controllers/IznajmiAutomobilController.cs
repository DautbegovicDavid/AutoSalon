using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autosalon.Models;
using AutoSalon.Models.ViewModels.AutomobilViewModels;
using AutoSalon.Models;
using AutoSalon.Data;
using Microsoft.EntityFrameworkCore;
using AutoSalon.Models.ViewModels.PoslovnicaViewModels;
using AutoSalon.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Controllers
{
    public class IznajmiAutomobilController : Controller
    {
        public List<SelectListItem> PripremaListItemGradovi()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite grad)"
                }
            };
            listItems.AddRange(db.Grad.Select(x => new SelectListItem()
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }));

            return listItems;
        }
        public List<SelectListItem> PripremaListItemProizvodjaci()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite proizvođača)"
                }
            };
            listItems.AddRange(db.Proizvodjac.Select(x => new SelectListItem()
            {
                Value = x.ProizvodjacID.ToString(),
                Text = x.Naziv
            }));

            return listItems;
        }
        //Priprema polosvnica
        public List<SelectListItem> PripremaListItemPoslovnice()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite poslovnicu)"
                }
            };
            listItems.AddRange(db.Poslovnica.Include(i=>i.Grad.Drzava).Select(x => new SelectListItem()
            {
                Value = x.PoslovnicaID.ToString(),
                Text = x.Naziv +" - "+ x.Grad.Drzava.Naziv +", "+x.Grad.Naziv + " - " + x.Adresa
            }));

            return listItems;
        }

        //Funkcija koja priprema listu tipova goriva
        public List<SelectListItem> PripremaListItemGoriva()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite vrstu goriva)"
                }
            };

            listItems.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Dizel"
            });
            listItems.Add(new SelectListItem()
            {
                Value ="2",
                Text = "Benzin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "3",
                Text = "Plin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "4",
                Text = "Hibrid"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "5",
                Text = "Elektro"
            });
            return listItems;
        }

        //Funkcija koja priprema listu tipova transmisije
        public List<SelectListItem> PripremaListItemTransmisije()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite vrstu transimisije)"
                }
            };

            listItems.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Automatic"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "2 (5+R)",
                Text = "Manualni (5+R)"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "3 (6+R)",
                Text = "Manualni (6+R)"
            });
            return listItems;
        }

        //Funkcija koja priprema listu tipova pogona
        public List<SelectListItem> PripremaListItemPogoni()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite vrstu pogona)"
                }
            };

            listItems.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Prednji"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Zadnji"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "3",
                Text = "4x4"
            });

            return listItems;
        }

        //Funkcija koja priprema listu tipova pogona
        public List<SelectListItem> PripremaListItemTipoviVozila()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite tip vozila)"
                }
            };

            listItems.Add(new SelectListItem()
            {
                Value = "Karavan",
                Text = "Karavan"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Limuzina",
                Text = "Limuzina"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Monovolumen",
                Text = "Monovolumen"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Coupe",
                Text = "Coupe"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "SUV",
                Text = "SUV"
            });

            return listItems;
        }

        //Funkcija koja priprema listu tipova emistionog standarda
        public List<SelectListItem> PripremaListItemTipoviEStandardi()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite tip emisionog standarda)"
                }
            };

            listItems.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Euro 3"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Euro 4"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "3",
                Text = "Euro 5"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "4",
                Text = "Euro 6"
            });

            return listItems;
        }

        //Funkcija koja priprema listu broja vrata
        public List<SelectListItem> PripremaListItemBrojVrata()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite broj vrata)"
                }
            };

            listItems.Add(new SelectListItem()
            {
                Value = "2/3",
                Text = "2/3"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "4/5",
                Text = "4/5"
            });


            return listItems;
        }
        public ApplicationDbContext db;
        public IznajmiAutomobilController (ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index(string Grad, string turistickaDestinacija, int? ProizvodjacID, int? PoslovnicaID, int? GorivoID,int ?PogonID,int? TransmisijaID,int ? EmisioniStandardID)
        {   /*pogon transmisija stanrd*/
            AutomobilRent model = new AutomobilRent();
            model.Proizvodjaci = PripremaListItemProizvodjaci();
            model.Proizvodjaci.FirstOrDefault().Text = "svi";
            model.Poslovnice = PripremaListItemPoslovnice();
            model.Poslovnice.FirstOrDefault().Text = "sve";
            model.Goriva = PripremaListItemGoriva();
            model.Goriva.FirstOrDefault().Text = "sve";
            model.Pogoni = PripremaListItemPogoni();
            model.Pogoni.FirstOrDefault().Text = "sve";
            model.Transmisije = PripremaListItemTransmisije();
            model.Transmisije.FirstOrDefault().Text = "sve";
            model.EmisioniStandardi = PripremaListItemTipoviEStandardi();
            model.EmisioniStandardi.FirstOrDefault().Text = "sve";
            string gorivo = "";
            string pogon = "";
            string emisionistandard = "";
            string transmisija = "";

            if (GorivoID!=null)
                gorivo = model.Goriva.Where(x => x.Value == GorivoID.ToString()).First().Text;
            if (PogonID != null)
                pogon = model.Pogoni.Where(x => x.Value == PogonID.ToString()).First().Text;
            if (EmisioniStandardID != null)
                emisionistandard = model.EmisioniStandardi.Where(x => x.Value == EmisioniStandardID.ToString()).First().Text;
            if (TransmisijaID != null)
                transmisija = model.Transmisije.Where(x => x.Value == TransmisijaID.ToString()).First().Text;

            if (turistickaDestinacija == "da")
            {
                model.TuristDest = Grad;
                model.auta = db.Automobil.Where(y => (y.AutomobilDetalji.Poslovnica.Grad.Naziv == Grad) && (y.ProizvodjacID == ProizvodjacID || ProizvodjacID == null) && (y.AutomobilDetalji.PoslovnicaID == PoslovnicaID || PoslovnicaID == null)/*|| y.ProizvodjacID > 1*/)
                    .Select(x => new AutomobilRent.Auto
                    {

                        Boja = x.Boja,
                        Model = x.Model,
                        Proizvodjac = x.Proizvodjac.Naziv,
                        GodinaProizvodnje = x.GodinaProizvodnje,
                        SlikaURL = x.SlikaURL,
                        Gorivo = x.AutomobilDetalji.Gorivo,
                        Transmisija = x.AutomobilDetalji.Transmisija,

                        Kilovati = x.AutomobilDetalji.Kilovati,
                        BrojSjedista = x.AutomobilDetalji.BrojSjedista,
                        BrojVrata = x.AutomobilDetalji.BrojVrata,
                        CijenaRentanja = x.AutomobilDetalji.CijenaRentanja,

                        Pogon = x.AutomobilDetalji.Pogon,
                        Kubikaza = x.AutomobilDetalji.Kubikaza,
                        EmisioniStandard = x.AutomobilDetalji.Poslovnica.Grad.Naziv



                    }).ToList();

            }
            else
            {
                model.TuristDest = "ne";
                model.auta = db.Automobil.Where(y => (y.ProizvodjacID == ProizvodjacID || ProizvodjacID == null) && 
                (y.AutomobilDetalji.PoslovnicaID == PoslovnicaID || PoslovnicaID == null) && 
                (y.AutomobilDetalji.Gorivo == gorivo || gorivo=="") &&
                (y.AutomobilDetalji.Pogon == pogon || pogon == "") &&
                (y.AutomobilDetalji.Transmisija == transmisija || transmisija == "")&&
                (y.AutomobilDetalji.EmisioniStandard == emisionistandard || emisionistandard == ""))
                    .Select(x => new AutomobilRent.Auto
                {

                    Boja = x.Boja,
                    Model = x.Model,
                    Proizvodjac = x.Proizvodjac.Naziv,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    SlikaURL = x.SlikaURL,
                    Gorivo = x.AutomobilDetalji.Gorivo,
                    Transmisija = x.AutomobilDetalji.Transmisija,

                    Kilovati = x.AutomobilDetalji.Kilovati,
                    BrojSjedista = x.AutomobilDetalji.BrojSjedista,
                    BrojVrata = x.AutomobilDetalji.BrojVrata,
                    CijenaRentanja = x.AutomobilDetalji.CijenaRentanja,

                    Pogon = x.AutomobilDetalji.Pogon,
                    Kubikaza = x.AutomobilDetalji.Kubikaza,
                    EmisioniStandard = x.AutomobilDetalji.EmisioniStandard



                }).ToList();
            }
            
            return View(model);
            
        }
        public IActionResult KreirajRezervaciju()
        {
            RegisterViewModel model = new RegisterViewModel()   
            {
                Gradovi = PripremaListItemGradovi()
            };
            return View(model);

            
        }
       
    }
}