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

namespace AutoSalon.Controllers
{
    public class IznajmiAutomobilController : Controller
    {
        public ApplicationDbContext db;
        public IznajmiAutomobilController (ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            AutomobilRent model = new AutomobilRent();

            model.auta = db.Automobil.Select(x => new AutomobilRent.Auto
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
                
                Pogon=x.AutomobilDetalji.Pogon,
                Kubikaza=x.AutomobilDetalji.Kubikaza,
                EmisioniStandard=x.AutomobilDetalji.EmisioniStandard



            }).ToList();

            return View(model);
        }
        public IActionResult KreirajRezervaciju()
        {
           

            return View();
        }
    }
}