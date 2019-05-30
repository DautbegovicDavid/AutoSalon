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
using AutoSalon.Models.ViewModels.IznajmiAutomobilViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Security.Claims;

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
        public List<SelectListItem> PripremaListItemPoslovnice(int id)
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite poslovnicu)",

                }
            };
            listItems.AddRange(db.Poslovnica.Include(i => i.Grad.Drzava).Select(x => new SelectListItem()
            {
                Value = x.PoslovnicaID.ToString(),
                Text = x.Naziv + " - " + x.Grad.Drzava.Naziv + ", " + x.Grad.Naziv + " - " + x.Adresa,
                Selected = (x.PoslovnicaID == id)
            }));

            return listItems;
        }
        public List<SelectListItem> PripremaListItemPoslovnice()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite poslovnicu)",

                }
            };
            listItems.AddRange(db.Poslovnica.Include(i => i.Grad.Drzava).Select(x => new SelectListItem()
            {
                Value = x.PoslovnicaID.ToString(),
                Text = x.Naziv + " - " + x.Grad.Drzava.Naziv + ", " + x.Grad.Naziv + " - " + x.Adresa,

            }));

            return listItems;
        }
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
                Value = "2",
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

        public int getLokacijaID(int id)
        {
            Automobil a = db.Automobil.Include(i => i.AutomobilDetalji).Where(w => w.AutomobilID == id).First();
            id = a.AutomobilDetalji.PoslovnicaID;
            return id;
        }
        public string getImePoslvnice(int id)
        {
            Poslovnica p = db.Poslovnica.Include(i => i.Grad.Drzava).Where(w => w.PoslovnicaID == id).First();
            string naziv = p.Grad.Drzava.Naziv.ToString() + ", " + p.Grad.Naziv.ToString() + "  " + p.Adresa + " - " + p.Naziv.ToString();
            return naziv;
        }
        public decimal getCijenaRentanje(int id)
        {
            decimal rentCijena;
            Automobil a = db.Automobil.Include(i => i.AutomobilDetalji).Where(w => w.AutomobilID == id).First();
            rentCijena = a.AutomobilDetalji.CijenaRentanja.Value;
            return rentCijena;
        }
        public Automobil getAuto(int id)
        {
            Automobil a = db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == id).First();
            return a;
        }
        public int getPoslovnicaID(string grad)
        {
            Poslovnica p = db.Poslovnica.Include(i => i.Grad).Where(w => w.Grad.Naziv == grad).FirstOrDefault();
            int _ID = db.Poslovnica.Include(i => i.Grad).Where(w => w.Grad.Naziv == grad).Select(s => s.PoslovnicaID).FirstOrDefault();
            _ID = p.PoslovnicaID;

            return _ID;
        }
        public double getCijenaOpreme(string ime)
        {
            DodatnaOprema dOp = db.DodatnaOprema.Where(w => w.Naziv == ime).First();
            return dOp.Cijena;
        }
        public int getIDOprema(string ime)
        {
            DodatnaOprema dOp = db.DodatnaOprema.Where(w => w.Naziv == ime).First();
            return dOp.DodatnaOpremaID;
        }
        public int getUposlenika(int id)
        {
            UposlenikPoslovnica up = db.UposlenikPoslovnica.Where(w => w.PoslovnicaID == id).First();
            return up.UposlenikID;
        }

        public IznajmiAutomobilController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index(string Grad, string turistickaDestinacija, int? ProizvodjacID, int? PoslovnicaID, int? GorivoID, int? PogonID, int? TransmisijaID, int? EmisioniStandardID)
        {

            AutomobilRent model = new AutomobilRent();

            model.Proizvodjaci = PripremaListItemProizvodjaci();
            model.Proizvodjaci.FirstOrDefault().Text = "svi";
            if (turistickaDestinacija == "da")
                model.Poslovnice = PripremaListItemPoslovnice(getPoslovnicaID(Grad));
            else
                model.Poslovnice = PripremaListItemPoslovnice();

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

            if (GorivoID != null)
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
                model.auta = db.Automobil.Where(y => (y.AutomobilDetalji.Poslovnica.Grad.Naziv == Grad) &&
                (y.ProizvodjacID == ProizvodjacID || ProizvodjacID == null) &&
                (y.AutomobilDetalji.PoslovnicaID == PoslovnicaID || PoslovnicaID == null))
                .Select(x => new AutomobilRent.Auto
                {
                    AutomobilID = x.AutomobilID,
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
                (y.AutomobilDetalji.Gorivo == gorivo || gorivo == "") &&
                (y.AutomobilDetalji.Pogon == pogon || pogon == "") &&
                (y.AutomobilDetalji.Transmisija == transmisija || transmisija == "") &&
                (y.AutomobilDetalji.EmisioniStandard == emisionistandard || emisionistandard == ""))
                .Select(x => new AutomobilRent.Auto
                {
                        AutomobilID = x.AutomobilID,
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
   
        public IActionResult KreirajRezervaciju(int AutomobilID)
        {

            KreirajRezervacijuVM model = new KreirajRezervacijuVM();
            Automobil a = getAuto(AutomobilID);
            model.AutomobilID = AutomobilID;
            model.PoslovnicaID = getLokacijaID(AutomobilID);
            model.nazivPoslovnice = getImePoslvnice(model.PoslovnicaID);
            model.DatumPreuzimanja = DateTime.Today;
            model.DatumVracanja = DateTime.Today.AddDays(1);       
            model.Iznos = getCijenaRentanje(model.AutomobilID);
            model.Model = a.Model;
            model.Proizvodjac = a.Proizvodjac.Naziv;
            model.SlikaURL = a.SlikaURL;
            model.Boja = a.Boja;

            int x = 0;
            string klijentID=User.FindFirstValue(ClaimTypes.NameIdentifier);
            Int32.TryParse(klijentID.ToString(),out x);
            model.KlijentID = x;
            //get id od logged usera
            model.UposlenikID = getUposlenika(model.PoslovnicaID);

            return View(model);

        }
     
        public IActionResult Snimi(KreirajRezervacijuVM model)
        {
            

            double cijenaOpreme = 0;
            List<int> OpremaIDs = new List<int>();
            List<string> opremaListaCijene = new List<string>();
            List<string> opremaListaNaziv = new List<string>();


            if (model.DjecijaSjedalica || model.KrovniKofer || model.KrovniNosaci || model.NosaciSkije || model.NosaciBicikla)
            {
                if (model.DjecijaSjedalica)
                { cijenaOpreme += getCijenaOpreme("DjecijaSjedalica"); OpremaIDs.Add(getIDOprema("DjecijaSjedalica")); opremaListaCijene.Add(getCijenaOpreme("DjecijaSjedalica").ToString()+" KM"); opremaListaNaziv.Add("Djecija sjedalica "); }
                if (model.KrovniKofer)
                { cijenaOpreme += getCijenaOpreme("KrovniKofer"); OpremaIDs.Add(getIDOprema("KrovniKofer")); opremaListaCijene.Add(getCijenaOpreme("KrovniKofer").ToString()+" KM"); opremaListaNaziv.Add("Krovni kofer "); }
                if (model.KrovniNosaci)
                { cijenaOpreme += getCijenaOpreme("KrovniNosaci"); OpremaIDs.Add(getIDOprema("KrovniNosaci")); opremaListaCijene.Add(getCijenaOpreme("KrovniNosaci").ToString()+" KM"); opremaListaNaziv.Add("Krovni nosaci "); }
                if (model.NosaciSkije)
                { cijenaOpreme += getCijenaOpreme("NosaciSkije"); OpremaIDs.Add(getIDOprema("NosaciSkije")); opremaListaCijene.Add(getCijenaOpreme("NosaciSkije").ToString()+" KM"); opremaListaNaziv.Add("Nosaci za skije "); }
                if (model.NosaciBicikla)
                { cijenaOpreme += getCijenaOpreme("NosaciBicikla"); OpremaIDs.Add(getIDOprema("NosaciBicikla")); opremaListaCijene.Add(getCijenaOpreme("NosaciBicikla").ToString()+" KM"); opremaListaNaziv.Add("Nosaci za bicikla "); }

            }

            double brojDana = Math.Ceiling((model.DatumVracanja - model.DatumPreuzimanja).TotalDays);
            decimal cijenaRentanjeDan = getCijenaRentanje(model.AutomobilID);

            if (brojDana <= 0)
                brojDana = 1;

            model.Iznos = cijenaRentanjeDan * System.Convert.ToDecimal(brojDana) + System.Convert.ToDecimal(cijenaOpreme);
            model.IznosbezPopusta= cijenaRentanjeDan * System.Convert.ToDecimal(brojDana) + System.Convert.ToDecimal(cijenaOpreme);
            model.IznosbezOpreme = cijenaRentanjeDan * System.Convert.ToDecimal(brojDana);
            int brrezervacija = db.RezervacijaRentanja.Where(w => w.KlijentID == model.KlijentID).Count();
            double popust = 0;

            if (brrezervacija >= 1 && brrezervacija <= 5)
            { model.Iznos = model.Iznos - (model.Iznos / 100) * 10; popust = 10; }
            if (brrezervacija > 5)
            { model.Iznos = model.Iznos - (model.Iznos / 100) * 15; popust = 15; }
        

            Racun racun = new Racun { DatumIzdavanja = DateTime.Now, Iznos = model.Iznos };
            db.Add(racun);
            db.SaveChanges();
            int racunID = db.Racun.Last().RacunID;

            RezervacijaRentanje rr = new RezervacijaRentanje { AutomobilID = model.AutomobilID,
                UposlenikID =model.UposlenikID, KlijentID =model.KlijentID, PoslovnicaID=model.PoslovnicaID,DatumKreiranja=DateTime.Now,
                RezervacijaOd=model.DatumPreuzimanja,RezervacijaDo=model.DatumVracanja,Iznos=model.Iznos,Popust=popust,Opis="/",RacunID=racunID

            };

            db.Add(rr);
            db.SaveChanges();

            RacunVM racunVM = new RacunVM();

            if (cijenaOpreme!=0)
            {
                foreach(int x in OpremaIDs)
                {
                    RezervacijaRentanjaDodatnaOprema rrdo = new RezervacijaRentanjaDodatnaOprema { DodatnaOpremaID = x, RezervacijaRentanjaID = rr.RezervacijaRentanjaID };
                    db.Add(rrdo);
                    db.SaveChanges();
                    racunVM.Oprema = true;
                }
            }

            Automobil a = db.Automobil.Find(model.AutomobilID);
            a.Dostupan = false;

            model.Popust = popust;
            model.CijenaOpreme = cijenaOpreme;
            model.DatumKreiranja = DateTime.Now;

            

            Poslovnica p = db.Poslovnica.Include(i=>i.Grad.Drzava).Where(w => w.PoslovnicaID == model.PoslovnicaID).First();
            racunVM.adresaPoslovnice = p.Adresa.ToString();
            racunVM.DrzavaGradPoslovnica = p.Grad.Drzava.Naziv + " " + p.Grad.Naziv + " "+p.Naziv;
            racunVM.Uposlenik = db.Users.Where(w => w.Id == model.UposlenikID).First().Prezime + db.Users.Where(w => w.Id == model.UposlenikID).First().Ime;
            racunVM.KlijentEmail = db.Users.Where(w => w.Id == model.KlijentID).First().Email;
            racunVM.RacunID = rr.RezervacijaRentanjaID;
            racunVM.Popust = popust;
            racunVM.nazivPoslovnice = p.Naziv;
            racunVM.KlijentImePrezime = db.Users.Where(w => w.Id == model.KlijentID).First().Prezime + " "+db.Users.Where(w => w.Id == model.UposlenikID).First().Ime;
            if (db.Users.Include(i => i.Grad).Where(w => w.Id == model.KlijentID).FirstOrDefault().Grad != null)
                racunVM.KlijentGrad = db.Users.Include(i => i.Grad).Where(w => w.Id == model.KlijentID).FirstOrDefault().Grad.Naziv.ToString();
            else racunVM.KlijentGrad = "/";
            racunVM.CijenaOpreme = cijenaOpreme;
            racunVM.DatumKreiranja = model.DatumKreiranja;
            racunVM.DatumPreuzimanja = model.DatumPreuzimanja;
            racunVM.DatumVracanja = model.DatumVracanja;
            racunVM.Iznos = model.Iznos;
            racunVM.IznosbezOpreme = model.IznosbezOpreme;
            racunVM.IznosbezPopusta = model.IznosbezPopusta;
            racunVM.Automobil = db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == model.AutomobilID).First().Proizvodjac.Naziv + " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == model.AutomobilID).First().Model;
            racunVM.brojDana = brojDana;
            racunVM.cijenaPoDanu = db.Automobil.Include(i => i.AutomobilDetalji).Where(x => x.AutomobilID == model.AutomobilID).First().AutomobilDetalji.CijenaRentanja;
            racunVM.AutomobilDetalji=db.Automobil.Include(i => i.AutomobilDetalji).Where(x => x.AutomobilID == model.AutomobilID).First().AutomobilDetalji.KonjskeSnage + " ks " + db.Automobil.Include(i => i.AutomobilDetalji).Where(x => x.AutomobilID == model.AutomobilID).First().AutomobilDetalji.Gorivo + " " + db.Automobil.Include(i => i.AutomobilDetalji).Where(x => x.AutomobilID == model.AutomobilID).First().AutomobilDetalji.Pogon;
            
            if(opremaListaCijene.Count!=0)
            {
                racunVM.ListaOpremaCijene = opremaListaCijene;
                racunVM.ListaOpremaNaziv = opremaListaNaziv;

            }
            return View(racunVM);


        }

    }
}