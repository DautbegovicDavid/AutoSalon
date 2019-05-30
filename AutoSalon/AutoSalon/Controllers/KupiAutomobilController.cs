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
    public class KupiAutomobilController : Controller
    {
        
        public ApplicationDbContext db;
        public KupiAutomobilController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            
                return View();
            
        }
        public IActionResult NovaVozila()
        {

            AutomobilIndexVM model = new AutomobilIndexVM();
            model.Stanje = "Novo";

            model.Rows=db.Automobil.Where(q=>q.Novo==true && q.Dostupan==true   )
                .Select(x=>new AutomobilIndexVM.Row
                {
                AutomobilID = x.AutomobilID,
                Boja = x.Boja,
                Model = x.Model,
                GodinaProizvodnje = x.GodinaProizvodnje,
                Dostupan = x.Dostupan,
                Cijena = string.Format("{0:C}", db.AutomobilDetalji.FirstOrDefault(s => s.AutomobilID == x.AutomobilID).Cijena),
                Proizvodjac =x.Proizvodjac.Naziv,
                SlikaURL = x.SlikaURL,
                Stanje = x.Novo ? "Novo" : "Korišteno"
                }).ToList();


               return View("Vozila",model);
   
        }
        public IActionResult PolovnaVozila()
        {

            AutomobilIndexVM model = new AutomobilIndexVM();
            model.Stanje = "Koristeno";
            model.Rows = db.Automobil.Where(q => q.Novo == false&&q.Dostupan==true).Select(x => new AutomobilIndexVM.Row
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


            return View("Vozila",model);

        }
        public IActionResult VozilaUDolasku(string Stanje)
        {
            
            if (Stanje == "Novo")
            {
                AutomobilIndexVM model = new AutomobilIndexVM();
                model.Rows = db.Automobil.Where(q => q.Novo == true && q.Dostupan == false).Select(x => new AutomobilIndexVM.Row
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
                return PartialView(model);
            }
            else
            {
                AutomobilIndexVM model = new AutomobilIndexVM();
                model.Rows = db.Automobil.Where(q => q.Novo == false && q.Dostupan == false).Select(x => new AutomobilIndexVM.Row
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
                return PartialView(model);
            }

            

        }
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
    }
}