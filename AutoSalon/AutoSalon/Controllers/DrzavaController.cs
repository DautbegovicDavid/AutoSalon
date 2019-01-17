using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AutoSalon.Controllers
{
    [Authorize(Roles = "Administrator, Uposlenik")]

    public class DrzavaController : Controller
    {
        public ApplicationDbContext _context;
        public DrzavaController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            int brG = 0;
            List<Drzave> podaci = _context.Drzava.Select(x => new Drzave
            {

                DrzavaID = x.DrzavaID,
                Naziv = x.Naziv,
                brGradova = _context.Grad.Where(g => g.Drzava.Naziv == x.Naziv).Count()

            }).ToList();
            foreach(Drzave x in podaci)
            {
                brG += x.brGradova;
            }
            DrzavaVM model = new DrzavaVM
            {
                podaci = podaci,
                ukupanBrUnesenihGradova = brG
               
            };
            
            return View(model);
        }

        public IActionResult Izbrisi(int id, bool ajaxPoziv = false)
        {
            Drzava d = _context.Drzava.SingleOrDefault(x => x.DrzavaID == id);

            if (d == null)
                return View("Error");

            _context.Remove(d);
            _context.SaveChanges();
            if (ajaxPoziv)
                return PartialView("Index");
            TempData["porukaSuccess"] = "Uspjesno je obrisan zapis";
            return RedirectToAction("Index");
            

        }
       
        public IActionResult Snimi(DrzavaDodajVM model)
        {
            Drzava d = _context.Drzava.Find(model.Drzava.DrzavaID);

            if (d == null)
            {
                d = new Drzava { Naziv = model.Drzava.Naziv };
                _context.Add(d);
                _context.SaveChanges();
            }
            else
            {
                d.Naziv = model.Drzava.Naziv;
                _context.SaveChanges();
            }
            TempData["porukaSuccess"] = "Uspjesno je snimljen/dodat zapis"; 
            
            return RedirectToAction("Index");

        }
        public IActionResult UrediDodaj(int? id)
        { 
            DrzavaDodajVM model = new DrzavaDodajVM { Drzava = _context.Drzava.Find(id) };
            return View(model);
        }


    }
}

