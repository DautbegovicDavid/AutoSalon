using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autosalon.Models;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;
using AutoSalon.Models.ViewModels.AutomobilViewModels;
using AutoSalon.Models.ViewModels.KupiAutomobilViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AutoSalon.Controllers
{
    public class KupiAutomobilController : Controller
    {

        public ApplicationDbContext db;
        public IHostingEnvironment he;
        public KupiAutomobilController(ApplicationDbContext context,IHostingEnvironment _he)
        {
            db = context;
            he = _he;
        }
        public List<SelectListItem> PripremaListItemProizvodjaci()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="Izaberite"
                }
            };
            listItems.AddRange(db.Proizvodjac.Select(x => new SelectListItem()
            {
                Value = x.ProizvodjacID.ToString(),
                Text = x.Naziv
            }));

            return listItems;
        }
        public List<SelectListItem> PripremaListItemEmisioniStandardi()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="Izaberite"
                }
            };

            listItems.AddRange(db.AutomobilDetalji.Select(x => x.EmisioniStandard.ToString()).Distinct().Select(x => new SelectListItem()
            {
                Value = x.ToString(),
                Text = x.ToString()
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
                    Text="Izaberite"
                }
            };

            listItems.AddRange(db.AutomobilDetalji.Select(x => x.Gorivo.ToString()).Distinct().Select(x => new SelectListItem()
            {
                Value = x.ToString(),
                Text = x.ToString()
            }));

            return listItems;
        }
        public List<SelectListItem> PripremaListItemTransimisije()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="Izaberite"
                }
            };
            listItems.AddRange(db.AutomobilDetalji.Select(x => x.Transmisija.ToString()).Distinct().Select(x => new SelectListItem()
            {
                Value = x.ToString(),
                Text = x.ToString()
            }));
            return listItems;
        }
        public List<SelectListItem> PripremaListItemPogoni()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="Izaberite"
                }
            };
            listItems.AddRange(db.AutomobilDetalji.Select(x => x.Pogon.ToString()).Distinct().Select(x => new SelectListItem()
            {
                Value = x.ToString(),
                Text = x.ToString()
            }));
            return listItems;
        }
        public List<SelectListItem> PripremaListItemModeli(int? proizvodjacID)
        {

            List<SelectListItem> listItems = new List<SelectListItem>()
            {
              new SelectListItem()
              {
                    Value = string.Empty,
                    Text = "Izaberite"

              }
            };

            listItems.AddRange(db.Automobil.Where(w => w.ProizvodjacID == proizvodjacID || proizvodjacID == null).Select(x => new SelectListItem()
            {
                Value = x.Model.ToString(),
                Text = x.Model.ToString()
            }));

            return listItems;
        }
        public List<SelectListItem> PripremaListItemPoslovnice() {
            List<SelectListItem> listItems = new List<SelectListItem>() {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="Izaberite"
                }
            };
            listItems.AddRange(db.Poslovnica.Include(i=>i.Grad).Select(x => new SelectListItem()
            {
                Value = x.PoslovnicaID.ToString(),
                Text = x.Naziv + " " + x.Grad.Naziv
            }));
            return listItems;
        }
        public List<SelectListItem> PripremaListItemStanje()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="Izaberite"
                }
            };
            listItems.Add(new SelectListItem()
            {
                Value = "PolovnaVozila",
                Text = "Polovno"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "NovaVozila",
                Text = "Novo"
            });
            return listItems;
        }


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
        public decimal getCijenaAuta(int id)
        {
            decimal Cijena;
            Automobil a = db.Automobil.Include(i => i.AutomobilDetalji).Where(w => w.AutomobilID == id).First();
            Cijena = a.AutomobilDetalji.Cijena;
            return Cijena;
        }
        public Automobil getAuto(int id)
        {
            Automobil a = db.Automobil.Include(i => i.Proizvodjac).Include(i=>i.AutomobilDetalji).Where(w => w.AutomobilID == id).First();
            return a;
        }
        public int getPoslovnicaID(string grad)
        {
            Poslovnica p = db.Poslovnica.Include(i => i.Grad).Where(w => w.Grad.Naziv == grad).FirstOrDefault();
            int _ID = db.Poslovnica.Include(i => i.Grad).Where(w => w.Grad.Naziv == grad).Select(s => s.PoslovnicaID).FirstOrDefault();
            _ID = p.PoslovnicaID;

            return _ID;
        }
        
        
        public int getUposlenika(int id)
        {
            UposlenikPoslovnica up = db.UposlenikPoslovnica.Where(w => w.PoslovnicaID == id).First();
            return up.UposlenikID;
        }
        


        public IActionResult Index()
        {

            return View();

        }
        public IActionResult Vozila(string stanje, int? ProizvodjacID, string Model, string EmisioniStandard, string Gorivo, string Transmisija, string Pogon, int? godisteOD, int? godisteDO, decimal? cijenaOD, decimal? cijenaDO, int? kilometrazaOD, int? kilometrazaDO, int? poslovnicaID, int? konjeOD, int? KonjeDO)
        {
            AutomobilKupiVM model = new AutomobilKupiVM();
            model.stanje = stanje;

            model.proizvodjaci = PripremaListItemProizvodjaci();
            model.emisioniStandardi = PripremaListItemEmisioniStandardi();
            model.modeli = PripremaListItemModeli(ProizvodjacID);
            model.goriva = PripremaListItemGoriva();
            model.transimisije = PripremaListItemTransimisije();
            model.pogoni = PripremaListItemPogoni();
            model.poslovnice = PripremaListItemPoslovnice();
            model.stanja = PripremaListItemStanje();
            if (stanje == "NovaVozila")
            {

                model.automobili1 = db.Automobil.Where(q => q.Novo == true && (q.ProizvodjacID == ProizvodjacID || ProizvodjacID == null)
                && (q.Model == Model || Model == null) && (q.AutomobilDetalji.EmisioniStandard == EmisioniStandard || EmisioniStandard == null)
                && (q.AutomobilDetalji.Gorivo == Gorivo || Gorivo == null) && (q.AutomobilDetalji.Transmisija == Transmisija || Transmisija == null)
                && (q.AutomobilDetalji.Pogon == Pogon || Pogon == null) && (q.GodinaProizvodnje >= godisteOD || godisteOD == null) && (q.GodinaProizvodnje <= godisteDO || godisteDO == null)
                && (q.AutomobilDetalji.Cijena >= cijenaOD || cijenaOD == null) && (q.AutomobilDetalji.Cijena <= cijenaDO || cijenaDO == null)
                && (q.AutomobilDetalji.Kilometraza >= kilometrazaOD || kilometrazaOD == null) && (q.AutomobilDetalji.Kilometraza <= kilometrazaDO || kilometrazaDO == null)
                && (q.AutomobilDetalji.PoslovnicaID == poslovnicaID || poslovnicaID == null) && (q.AutomobilDetalji.KonjskeSnage >= konjeOD || konjeOD== null)
                && (q.AutomobilDetalji.KonjskeSnage <= KonjeDO || KonjeDO==null)
                
                ).Select(x => new AutomobilKupiVM.Row
                {
                    AutomobilID = x.AutomobilID,
                    Boja = x.Boja,
                    Model = x.Model,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    Dostupan = x.Dostupan,
                    Cijena = string.Format("{0:C}", db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
                    Proizvodjac = x.Proizvodjac.Naziv,
                    SlikaURL = x.SlikaURL,
                    Stanje = x.Novo ? "Novo" : "Korišteno"
                }
                ).ToList();
               
                
            }
            else if(stanje=="PolovnaVozila")
            {
                model.automobili1 = db.Automobil.Where(q => q.Novo == false && (q.ProizvodjacID == ProizvodjacID || ProizvodjacID == null)
                && (q.Model == Model || Model == null) && (q.AutomobilDetalji.EmisioniStandard == EmisioniStandard || EmisioniStandard == null)
                && (q.AutomobilDetalji.Gorivo == Gorivo || Gorivo == null) && (q.AutomobilDetalji.Transmisija == Transmisija || Transmisija == null)
                && (q.AutomobilDetalji.Pogon == Pogon || Pogon == null) && (q.GodinaProizvodnje >= godisteOD || godisteOD == null) && (q.GodinaProizvodnje <= godisteDO || godisteDO == null)
                && (q.AutomobilDetalji.Cijena >= cijenaOD || cijenaOD == null) && (q.AutomobilDetalji.Cijena <= cijenaDO || cijenaDO == null)
                && (q.AutomobilDetalji.Kilometraza >= kilometrazaOD || kilometrazaOD == null) && (q.AutomobilDetalji.Kilometraza <= kilometrazaDO || kilometrazaDO == null)
                && (q.AutomobilDetalji.PoslovnicaID == poslovnicaID || poslovnicaID == null) && (q.AutomobilDetalji.KonjskeSnage >= konjeOD || konjeOD == null)
                && (q.AutomobilDetalji.KonjskeSnage <= KonjeDO || KonjeDO == null)

                ).Select(x => new AutomobilKupiVM.Row
                {
                   AutomobilID = x.AutomobilID,
                   Boja = x.Boja,
                   Model = x.Model,
                   GodinaProizvodnje = x.GodinaProizvodnje,
                   Dostupan = x.Dostupan,
                   Cijena = string.Format("{0:C}", db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
                   Proizvodjac = x.Proizvodjac.Naziv,
                   SlikaURL = x.SlikaURL,
                   Stanje = x.Novo ? "Novo" : "Korišteno"
                }).ToList();
            }
            else
            {
                model.automobili1 = db.Automobil.Where(q=>(q.ProizvodjacID == ProizvodjacID || ProizvodjacID == null)
                && (q.Model == Model || Model == null) && (q.AutomobilDetalji.EmisioniStandard == EmisioniStandard || EmisioniStandard == null)
                && (q.AutomobilDetalji.Gorivo == Gorivo || Gorivo == null) && (q.AutomobilDetalji.Transmisija == Transmisija || Transmisija == null)
                && (q.AutomobilDetalji.Pogon == Pogon || Pogon == null) && (q.GodinaProizvodnje >= godisteOD || godisteOD == null) && (q.GodinaProizvodnje <= godisteDO || godisteDO == null)
                && (q.AutomobilDetalji.Cijena >= cijenaOD || cijenaOD == null) && (q.AutomobilDetalji.Cijena <= cijenaDO || cijenaDO == null)
                && (q.AutomobilDetalji.Kilometraza >= kilometrazaOD || kilometrazaOD == null) && (q.AutomobilDetalji.Kilometraza <= kilometrazaDO || kilometrazaDO == null)
                && (q.AutomobilDetalji.PoslovnicaID == poslovnicaID || poslovnicaID == null) && (q.AutomobilDetalji.KonjskeSnage >= konjeOD || konjeOD == null)
                && (q.AutomobilDetalji.KonjskeSnage <= KonjeDO || KonjeDO == null)

                ).Select(x => new AutomobilKupiVM.Row
                {
                    AutomobilID = x.AutomobilID,
                    Boja = x.Boja,
                    Model = x.Model,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    Dostupan = x.Dostupan,
                    Cijena = string.Format("{0:C}", db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
                    Proizvodjac = x.Proizvodjac.Naziv,
                    SlikaURL = x.SlikaURL,
                    Stanje = x.Novo ? "Novo" : "Korišteno"
                }).ToList();

            }
            return View(model);



        }
       
        //public IActionResult VozilaUDolasku(string Stanje)
        //{
            
        //    if (Stanje == "Novo")
        //    {
        //        AutomobilIndexVM model = new AutomobilIndexVM();
        //        model.Rows = db.Automobil.Where(q => q.Novo == true && q.Dostupan == false).Select(x => new AutomobilIndexVM.Row
        //        {
        //            AutomobilID = x.AutomobilID,
        //            Boja = x.Boja,
        //            Model = x.Model,
        //            GodinaProizvodnje = x.GodinaProizvodnje,
        //            Dostupan = x.Dostupan,
        //            Cijena = string.Format("{0:C}", db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
        //            Proizvodjac = x.Proizvodjac.Naziv,
        //            SlikaURL = x.SlikaURL,
        //            Stanje = x.Novo ? "Novo" : "Korišteno"
        //        }).ToList();
        //        return PartialView(model);
        //    }
        //    else
        //    {
        //        AutomobilIndexVM model = new AutomobilIndexVM();
        //        model.Rows = db.Automobil.Where(q => q.Novo == false && q.Dostupan == false).Select(x => new AutomobilIndexVM.Row
        //        {
        //            AutomobilID = x.AutomobilID,
        //            Boja = x.Boja,
        //            Model = x.Model,
        //            GodinaProizvodnje = x.GodinaProizvodnje,
        //            Dostupan = x.Dostupan,
        //            Cijena = string.Format("{0:C}", db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
        //            Proizvodjac = x.Proizvodjac.Naziv,
        //            SlikaURL = x.SlikaURL,
        //            Stanje = x.Novo ? "Novo" : "Korišteno"
        //        }).ToList();
        //        return PartialView(model);
        //    }

            

        //}
        public IActionResult Detalji(int AutomobilID)
        {
            Automobil automobil = db.Automobil.Include(y => y.Proizvodjac).FirstOrDefault(x => x.AutomobilID == AutomobilID);
            AutomobilDetalji automobilDetalji = db.AutomobilDetalji.FirstOrDefault(x => x.AutomobilID == automobil.AutomobilID);

            AutomobilDetaljiVM model = new AutomobilDetaljiVM()
            {
                AutomobilID = AutomobilID,
                Model = automobil.Model,
                Boja = automobil.Boja,
                Novo = automobil.Novo,
                Dostupan = automobil.Dostupan,
                GodinaProizvodnje = automobil.GodinaProizvodnje,
                Proizvodjac = automobil.Proizvodjac.Naziv,
                SlikaURL = automobil.SlikaURL,
                EmisioniStandard = automobilDetalji.EmisioniStandard,
                Transmisija = automobilDetalji.Transmisija,
                Tip = automobilDetalji.Tip,
                Pogon = automobilDetalji.Pogon,
                BrojVrata = automobilDetalji.BrojVrata,
                Gorivo = automobilDetalji.Gorivo,
                Kilovati = automobilDetalji.Kilovati,
                KonjskeSnage = automobilDetalji.KonjskeSnage,
                VelicinaFelgi = automobilDetalji.VelicinaFelgi,
                BrojSjedista = automobilDetalji.BrojSjedista,
                Cijena = automobilDetalji.Cijena,
                Kilometraza = automobilDetalji.Kilometraza,
                Kubikaza = automobilDetalji.Kubikaza,
                Tezina = automobilDetalji.Tezina,
                CijenaRentanja = automobilDetalji.CijenaRentanja

            };
            return View(model);
        }

        public IActionResult KreirajRezervaciju(int AutomobilID)
        {
            RezervisiAutomobilVM model = new RezervisiAutomobilVM();
            Automobil a = getAuto(AutomobilID);
            model.AutomobilID = AutomobilID;
            model.PoslovnicaID = getLokacijaID(AutomobilID);
            model.nazivPoslovnice = getImePoslvnice(model.PoslovnicaID);
            model.DatumPreuzimanja = DateTime.Today;
            model.poslovnice = PripremaListItemPoslovnice();
            model.Iznos = getCijenaAuta(AutomobilID);
            model.Model = a.Model;
            model.Proizvodjac = a.Proizvodjac.Naziv;
            model.SlikaURL = a.SlikaURL;
            model.Boja = a.Boja;
            model.Gorivo = a.AutomobilDetalji.Gorivo;
            model.Motor = a.AutomobilDetalji.Kubikaza;
            model.Godiste = a.GodinaProizvodnje.ToString();

            int x = 0;
            string klijentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Int32.TryParse(klijentID.ToString(), out x);
            model.KlijentID = x;
            //get id od logged usera
            model.UposlenikID = getUposlenika(model.PoslovnicaID);

            return View(model);
            
        }
        public IActionResult Snimi(RezervisiAutomobilVM model)
        {


            RezervacijaKupovina rt = new RezervacijaKupovina
            {
                AutomobilID = model.AutomobilID,
                UposlenikID = model.UposlenikID,
                KlijentID = model.KlijentID,
                PoslovnicaID = model.PoslovnicaID,
                DatumKreiranja = DateTime.Now,
                DatumPreuzimanja = model.DatumPreuzimanja,
                Komentar=model.komentar,KompletiranaKupovina=false
                

            };
            db.Add(rt);
            db.SaveChanges();
            TempData["porukaSuccess"] = "Uspjesno je kreirana rezervacija";
            return RedirectToAction("Index", "Aktivnosti");

        }
    }
}