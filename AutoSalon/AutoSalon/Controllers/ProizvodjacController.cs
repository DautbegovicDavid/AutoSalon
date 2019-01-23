using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.ProizvodjacViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Controllers
{
    [Authorize(Roles = "Administrator, Uposlenik, Klijent")]
    public class ProizvodjacController : Controller
    {
        private ApplicationDbContext db;
        public ProizvodjacController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int? DrzavaID, string nazivProizvodjaca)
        {

            ProizvodjacIndexVM model = new ProizvodjacIndexVM();
            model.Drzave = PripremaListItemDrzave();
            if (nazivProizvodjaca != null)
                nazivProizvodjaca = nazivProizvodjaca.Replace(" ", "").ToLower();

            model.Rows = db.Proizvodjac.Where(y => (y.DrzavaID == DrzavaID || DrzavaID == null) && (y.Naziv.Replace(" ", "").ToLower().Contains(nazivProizvodjaca) || nazivProizvodjaca == null))
            .Select(x => new ProizvodjacIndexVM.Row
            {
                ProizvodjacID = x.ProizvodjacID,
                Naziv = x.Naziv,
                Drzava = x.Drzava.Naziv
            }).ToList();
           
            return View(model);
        }



        //Funkcija koja priprema listu drzava
        public List<SelectListItem> PripremaListItemDrzave()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite državu)"
                }
            };
            listItems.AddRange(db.Drzava.Select(x => new SelectListItem()
            {
                Value = x.DrzavaID.ToString(),
                Text = x.Naziv
            }));

            return listItems;
        }



        //Get Dodaj
        [Authorize(Roles = "Administrator, Uposlenik")]
        public IActionResult Dodaj()
        {
            ProizvodjacDodajVM model = new ProizvodjacDodajVM();
            model.Drzave = PripremaListItemDrzave();
            return View(model);
        }

        //Post Dodaj
        [HttpPost]
        [Authorize(Roles = "Administrator, Uposlenik")]
        public async Task<IActionResult> Dodaj(ProizvodjacDodajVM model)
        {
            Proizvodjac proizvodjac = new Proizvodjac()
            {
                Naziv=model.Naziv,
                DrzavaID=model.DrzavaID
            };
            db.Proizvodjac.Add(proizvodjac);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}