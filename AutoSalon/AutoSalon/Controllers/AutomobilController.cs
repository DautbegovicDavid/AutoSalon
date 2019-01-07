using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;
using AutoSalon.Models.ViewModels.AutomobilViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class AutomobilController : Controller
    {
        private ApplicationDbContext db;
        private IHostingEnvironment he;
        public AutomobilController(ApplicationDbContext _db, IHostingEnvironment _he)
        {
            db = _db;
            he = _he;
        }
        public IActionResult Index(int ? ProizvodjacID)
        {
            AutomobilIndexVM model = new AutomobilIndexVM();
            model.Proizvodjaci = PripremaListItemProizvodjaci();
            model.Proizvodjaci.FirstOrDefault().Text = "(Sva vozila)";


                model.Rows = db.Automobil.Where(y => y.ProizvodjacID == ProizvodjacID || ProizvodjacID==null)
                                         .Select(x => new AutomobilIndexVM.Row()
                {
                    AutomobilID = x.AutomobilID,
                    Boja = x.Boja,
                    Model = x.Model,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    Dostupan = x.Dostupan,
                    Cijena =string.Format("{0:C}" ,db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
                    Proizvodjac = x.Proizvodjac.Naziv,
                    SlikaURL = x.SlikaURL,
                    Stanje=x.Novo?"Novo":"Korišteno"
                }).ToList();
        

            return View(model);
        }


        //Funkcija koja priprema listu proizvođača
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

            listItems.Add( new SelectListItem()
            {
                Value ="Dizel",
                Text = "Dizel"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Benzin",
                Text = "Benzin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Plin",
                Text = "Plin"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Hibrid",
                Text = "Hibrid"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Elektro",
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
                Value = "Automatic",
                Text = "Automatic"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Manualni (5+R)",
                Text = "Manualni (5+R)"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Manualni (6+R)",
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
                Value = "Prednji",
                Text = "Prednji"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Zadnji",
                Text = "Zadnji"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "4x4",
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
                Value = "Euro 3",
                Text = "Euro 3"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Euro 4",
                Text = "Euro 4"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Euro 5",
                Text = "Euro 5"
            });
            listItems.Add(new SelectListItem()
            {
                Value = "Euro 6",
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


        public IActionResult Dodaj()
        {
            AutomobilDodajVM model = new AutomobilDodajVM();
            model.Proizvodjaci = PripremaListItemProizvodjaci();
            model.EmisioniStandardi = PripremaListItemTipoviEStandardi();
            model.Transmisije = PripremaListItemTransmisije();
            model.Tipovi = PripremaListItemTipoviVozila();
            model.Pogoni = PripremaListItemPogoni();
            model.BrojeviVrata = PripremaListItemBrojVrata();
            model.Goriva = PripremaListItemGoriva();

            return View(model);
        }

        [HttpPost]
        public async Task< IActionResult > Dodaj(AutomobilDodajVM AutomobilDodajVM, IFormFile SlikaURL)
        {
            Automobil automobil = new Automobil();
            automobil.Boja = AutomobilDodajVM.Boja;
            automobil.Dostupan = AutomobilDodajVM.Dostupan;
            automobil.GodinaProizvodnje = AutomobilDodajVM.GodinaProizvodnje;
            automobil.Model = AutomobilDodajVM.Model;
            if (AutomobilDodajVM.Kilometraza < 100)
                automobil.Novo = true;
            automobil.ProizvodjacID = AutomobilDodajVM.ProizvodjacID;
            automobil.SlikaURL = SlikaURL.FileName;

            if (ModelState.IsValid)
                db.Automobil.Add(automobil);

                AutomobilDetalji automobilDetalji = new AutomobilDetalji();
            automobilDetalji.AutomobilID = automobil.AutomobilID;
            automobilDetalji.BrojSjedista = AutomobilDodajVM.BrojSjedista;
            automobilDetalji.BrojVrata = AutomobilDodajVM.BrojVrata;
            automobilDetalji.Cijena = AutomobilDodajVM.Cijena;
            automobilDetalji.CijenaRentanja = AutomobilDodajVM.CijenaRentanja;
            automobilDetalji.EmisioniStandard = AutomobilDodajVM.EmisioniStandard;
            automobilDetalji.Gorivo = AutomobilDodajVM.Gorivo;
            automobilDetalji.Kilometraza = AutomobilDodajVM.Kilometraza;
            automobilDetalji.Kilovati = AutomobilDodajVM.Kilovati;
            automobilDetalji.KonjskeSnage =(int)((float)AutomobilDodajVM.Kilovati * 1.359);
            automobilDetalji.Kubikaza = AutomobilDodajVM.Kubikaza;
            automobilDetalji.Pogon = AutomobilDodajVM.Pogon;
            automobilDetalji.Tezina = AutomobilDodajVM.Tezina;
            automobilDetalji.Tip = AutomobilDodajVM.Tip;
            automobilDetalji.Transmisija = AutomobilDodajVM.Transmisija;
            automobilDetalji.VelicinaFelgi = AutomobilDodajVM.VelicinaFelgi;

         

            var filePath = Path.Combine(he.WebRootPath+ "\\images\\Automobili", SlikaURL.FileName);
            SlikaURL.CopyTo(new FileStream(filePath, FileMode.Create));

            if (ModelState.IsValid)
            {
                db.Automobil.Add(automobil);
                db.AutomobilDetalji.Add(automobilDetalji);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            AutomobilDodajVM.Proizvodjaci = PripremaListItemProizvodjaci();
            AutomobilDodajVM.EmisioniStandardi = PripremaListItemTipoviEStandardi();
            AutomobilDodajVM.Transmisije = PripremaListItemTransmisije();
            AutomobilDodajVM.Tipovi = PripremaListItemTipoviVozila();
            AutomobilDodajVM.Pogoni = PripremaListItemPogoni();
            AutomobilDodajVM.BrojeviVrata = PripremaListItemBrojVrata();
            AutomobilDodajVM.Goriva = PripremaListItemGoriva();

            return View(AutomobilDodajVM);
        }


        public IActionResult Uredi(int AutomobilID)
        {
            Automobil automobil = db.Automobil.FirstOrDefault(x => x.AutomobilID == AutomobilID);
            AutomobilDetalji automobilDetalji = db.AutomobilDetalji.FirstOrDefault(x => x.AutomobilID == automobil.AutomobilID);

            AutomobilUrediVM model = new AutomobilUrediVM()
            {
                AutomobilID=AutomobilID,
                Boja=automobil.Boja,
                Dostupan=automobil.Dostupan,
                GodinaProizvodnje=automobil.GodinaProizvodnje,
                Model=automobil.Model,
                Novo=automobil.Novo,
                SlikaURL=automobil.SlikaURL,
                ProizvodjacID=automobil.ProizvodjacID,
                EmisioniStandard = automobilDetalji.EmisioniStandard,
                Transmisija = automobilDetalji.Transmisija,
                Tip = automobilDetalji.Tip,
                Pogon = automobilDetalji.Pogon,
                BrojVrata = automobilDetalji.BrojVrata,
                Gorivo = automobilDetalji.Gorivo,
                Kilovati= automobilDetalji.Kilovati,
                VelicinaFelgi= automobilDetalji.VelicinaFelgi,
                BrojSjedista= automobilDetalji.BrojSjedista,
                Cijena= automobilDetalji.Cijena,
                Kilometraza= automobilDetalji.Kilometraza,
                Kubikaza= automobilDetalji.Kubikaza,
                Tezina= automobilDetalji.Tezina,
                CijenaRentanja=automobilDetalji.CijenaRentanja,
                Proizvodjaci = PripremaListItemProizvodjaci(),
                EmisioniStandardi = PripremaListItemTipoviEStandardi(),
                Transmisije = PripremaListItemTransmisije(),
                Tipovi = PripremaListItemTipoviVozila(),
                Pogoni = PripremaListItemPogoni(),
                BrojeviVrata = PripremaListItemBrojVrata(),
                Goriva = PripremaListItemGoriva()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(AutomobilUrediVM AutomobilUrediVM)
        {
            Automobil automobil = db.Automobil.FirstOrDefault(x => x.AutomobilID == AutomobilUrediVM.AutomobilID);
            AutomobilDetalji automobilDetalji = db.AutomobilDetalji.FirstOrDefault(x => x.AutomobilID == automobil.AutomobilID);

            automobil.Boja = AutomobilUrediVM.Boja;
            automobil.Dostupan = AutomobilUrediVM.Dostupan;
            automobil.GodinaProizvodnje = AutomobilUrediVM.GodinaProizvodnje;
            automobil.Model = AutomobilUrediVM.Model;
            if (AutomobilUrediVM.Kilometraza < 100)
                automobil.Novo = true;
            automobil.SlikaURL = AutomobilUrediVM.SlikaURL;
            automobil.ProizvodjacID = AutomobilUrediVM.ProizvodjacID;
            automobilDetalji.EmisioniStandard = AutomobilUrediVM.EmisioniStandard;
            automobilDetalji.Transmisija = AutomobilUrediVM.Transmisija;
            automobilDetalji.Tip = AutomobilUrediVM.Tip;
            automobilDetalji.Pogon = AutomobilUrediVM.Pogon;
            automobilDetalji.BrojVrata = AutomobilUrediVM.BrojVrata;
            automobilDetalji.Gorivo = AutomobilUrediVM.Gorivo;
            automobilDetalji.Kilovati = AutomobilUrediVM.Kilovati;
            automobilDetalji.KonjskeSnage = (int)((float)AutomobilUrediVM.Kilovati * 1.359);
            automobilDetalji.VelicinaFelgi = AutomobilUrediVM.VelicinaFelgi;
            automobilDetalji.BrojSjedista = AutomobilUrediVM.BrojSjedista;
            automobilDetalji.Cijena = AutomobilUrediVM.Cijena;
            automobilDetalji.Kilometraza = AutomobilUrediVM.Kilometraza;
            automobilDetalji.Kubikaza = AutomobilUrediVM.Kubikaza;
            automobilDetalji.Tezina = AutomobilUrediVM.Tezina;
            automobilDetalji.CijenaRentanja = AutomobilUrediVM.Cijena/365;

            if (ModelState.IsValid)
            {
                db.Update(automobil);
                db.Update(automobilDetalji);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            AutomobilUrediVM.Proizvodjaci = PripremaListItemProizvodjaci();
            AutomobilUrediVM.EmisioniStandardi = PripremaListItemTipoviEStandardi();
            AutomobilUrediVM.Transmisije = PripremaListItemTransmisije();
            AutomobilUrediVM.Tipovi = PripremaListItemTipoviVozila();
            AutomobilUrediVM.Pogoni = PripremaListItemPogoni();
            AutomobilUrediVM.BrojeviVrata = PripremaListItemBrojVrata();
            AutomobilUrediVM.Goriva = PripremaListItemGoriva();

            return View(AutomobilUrediVM);
        }

        public IActionResult Detalji(int AutomobilID)
        {
            Automobil automobil = db.Automobil.Include(y=> y.Proizvodjac).FirstOrDefault(x => x.AutomobilID == AutomobilID);
            AutomobilDetalji automobilDetalji = db.AutomobilDetalji.FirstOrDefault(x => x.AutomobilID == automobil.AutomobilID);

            AutomobilDetaljiVM model = new AutomobilDetaljiVM()
            {
                AutomobilID=AutomobilID,
                Model=automobil.Model,
                Boja=automobil.Boja,
                Novo=automobil.Novo,
                Dostupan=automobil.Dostupan,
                GodinaProizvodnje=automobil.GodinaProizvodnje,
                Proizvodjac=automobil.Proizvodjac.Naziv,
                SlikaURL=automobil.SlikaURL,
                EmisioniStandard = automobilDetalji.EmisioniStandard,
                Transmisija = automobilDetalji.Transmisija,
                Tip = automobilDetalji.Tip,
                Pogon = automobilDetalji.Pogon,
                BrojVrata = automobilDetalji.BrojVrata,
                Gorivo = automobilDetalji.Gorivo,
                Kilovati = automobilDetalji.Kilovati,
                KonjskeSnage=automobilDetalji.KonjskeSnage,
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


        //Get Ukloni
        public IActionResult Ukloni(int AutomobilID)
        {
            Automobil automobil = db.Automobil.Include(s=> s.Proizvodjac).FirstOrDefault(x => x.AutomobilID == AutomobilID);

            AutomobilUkloniVM model = new AutomobilUkloniVM()
            {
                AutomobilID = AutomobilID,
                Model = automobil.Model,
                GodinaProizvodnje = automobil.GodinaProizvodnje,
                Proizvodjac = automobil.Proizvodjac.Naziv,
                SlikaURL = automobil.SlikaURL
            };
            return View(model);
        }

        //Post Ukloni
        [HttpPost, ActionName("Ukloni")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UkloniPotvrda(int AutomobilID)
        {
            Automobil automobil = await db.Automobil.SingleOrDefaultAsync(p => p.AutomobilID == AutomobilID);
            db.Automobil.Remove(automobil);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}