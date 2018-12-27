using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class AutomobilController : Controller
    {
        private ApplicationDbContext db;
        public AutomobilController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int ? ProizvodjacID)
        {
            AutomobilIndexVM model = new AutomobilIndexVM();
            model.Proizvodjaci = PripremaListItemProizvodjaci();
            model.Proizvodjaci.FirstOrDefault().Text = "(Sva vozila)";

            if (ProizvodjacID != null)  {

                model.Rows = db.Automobil.Where(y => y.ProizvodjacID == ProizvodjacID).Select(x => new AutomobilIndexVM.Row()
                {
                    AutomobilID = x.AutomobilID,
                    Boja = x.Boja,
                    Model = x.Model,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    Dostupan = x.Dostupan,
                    Cijena = db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena,
                    Proizvodjac = x.Proizvodjac.Naziv,
                    SlikaURL = x.Slika
                }).ToList();
                }
            else{
                model.Rows = db.Automobil.Select(x => new AutomobilIndexVM.Row()
                {
                    AutomobilID = x.AutomobilID,
                    Boja = x.Boja,
                    Model = x.Model,
                    GodinaProizvodnje = x.GodinaProizvodnje,
                    Dostupan = x.Dostupan,
                    Cijena = db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena,
                    Proizvodjac = x.Proizvodjac.Naziv,
                    SlikaURL = x.Slika
                }).ToList();
                }

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


        
        public IActionResult Dodaj()
        {
            AutomobilDodajVM model = new AutomobilDodajVM();
            model.Proizvodjaci = PripremaListItemProizvodjaci();
           
            return View(model);
        }

        [HttpPost]
        public async Task< IActionResult > Dodaj(AutomobilDodajVM AutomobilDodajVM)
        {
            Automobil automobil = new Automobil();
            automobil.Boja = AutomobilDodajVM.Boja;
            automobil.Dostupan = AutomobilDodajVM.Dostupan;
            automobil.GodinaProizvodnje = AutomobilDodajVM.GodinaProizvodnje;
            automobil.Model = AutomobilDodajVM.Model;
            automobil.Novo = AutomobilDodajVM.Novo;
            automobil.ProizvodjacID = AutomobilDodajVM.ProizvodjacID;
            automobil.Slika = AutomobilDodajVM.SlikaURL;

            if (ModelState.IsValid)
            {
                db.Automobil.Add(automobil);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(AutomobilDodajVM);
        }


        public IActionResult Uredi(int AutomobilID)
        {
            Automobil automobil = db.Automobil.FirstOrDefault(x => x.AutomobilID == AutomobilID);

            AutomobilUrediVM model = new AutomobilUrediVM()
            {
                AutomobilID=AutomobilID,
                Boja=automobil.Boja,
                Dostupan=automobil.Dostupan,
                GodinaProizvodnje=automobil.GodinaProizvodnje,
                Model=automobil.Model,
                Novo=automobil.Novo,
                SlikaURL=automobil.Slika,
                ProizvodjacID=automobil.ProizvodjacID,
                Proizvodjaci=PripremaListItemProizvodjaci()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(AutomobilUrediVM AutomobilUrediVM)
        {
            Automobil automobil = db.Automobil.FirstOrDefault(x => x.AutomobilID == AutomobilUrediVM.AutomobilID);

            automobil.Boja = AutomobilUrediVM.Boja;
            automobil.Dostupan = AutomobilUrediVM.Dostupan;
            automobil.GodinaProizvodnje = AutomobilUrediVM.GodinaProizvodnje;
            automobil.Model = AutomobilUrediVM.Model;
            automobil.Novo = AutomobilUrediVM.Novo;
            automobil.Slika = AutomobilUrediVM.SlikaURL;
            automobil.ProizvodjacID = AutomobilUrediVM.ProizvodjacID;

            AutomobilUrediVM.Proizvodjaci = PripremaListItemProizvodjaci();

            if (ModelState.IsValid)
            {
                db.Update(automobil);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            AutomobilUrediVM.Proizvodjaci = PripremaListItemProizvodjaci();
            return View(AutomobilUrediVM);
        }

        public IActionResult Detalji(int AutomobilID)
        {
            Automobil automobil = db.Automobil.Include(y=> y.Proizvodjac).FirstOrDefault(x => x.AutomobilID == AutomobilID);
            AutomobilDetaljiVM model = new AutomobilDetaljiVM()
            {
                AutomobilID=AutomobilID,
                Model=automobil.Model,
                Boja=automobil.Boja,
                Novo=automobil.Novo,
                Dostupan=automobil.Dostupan,
                GodinaProizvodnje=automobil.GodinaProizvodnje,
                Proizvodjac=automobil.Proizvodjac.Naziv,
                SlikaURL=automobil.Slika
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
                SlikaURL = automobil.Slika
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