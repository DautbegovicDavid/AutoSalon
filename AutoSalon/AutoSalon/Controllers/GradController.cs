using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models.ViewModels;
using AutoSalon.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoSalon.Controllers
{
    public class GradController : Controller
    {
        public ApplicationDbContext _context;
        public GradController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<GradVM> podaci = _context.Grad.Select(x => new GradVM
            {
                GradID=x.GradID,
                Naziv=x.Naziv,
                Drzava=x.Drzava.Naziv,
                PostanskiBroj=x.PostanskiBroj

            }).ToList();

            ViewData["gradovi"] = podaci;

            return View();
        }

        public IActionResult Izbrisi(int id, bool ajaxPoziv = false)
        {
            Grad g = _context.Grad.SingleOrDefault(x => x.GradID == id);

            if (g == null)
                return View("Error");

            _context.Remove(g);
            _context.SaveChanges();
            if (ajaxPoziv)
                return PartialView("Index");
            TempData["porukaSuccess"] = "Uspjesno je izbrisan zapis";
            return RedirectToAction("index");
        }

        public IActionResult UrediDodaj(int? id)
        {
            Grad g = _context.Grad.SingleOrDefault(i => i.GradID == id);
            List<SelectListItem> drzave = _context.Drzava.Select(d => new SelectListItem { Text = d.Naziv.ToString(), Value = d.DrzavaID.ToString() }).ToList();
           
                GradDodajVM model = new GradDodajVM
                {
                    Drzava = drzave,
                    Grad = _context.Grad.Find(id)

                };
                return View(model); 
        }

        public IActionResult Snimi(GradDodajVM model)
        {
            Grad g = _context.Grad.Find(model.Grad.GradID);

            if (g == null)
            {
                g = new Grad { Naziv = model.Grad.Naziv,DrzavaID= model.Grad.DrzavaID,PostanskiBroj= model.Grad.PostanskiBroj };
                _context.Add(g);
                _context.SaveChanges();
            }
            else
            {
                g.Naziv = model.Grad.Naziv;
                g.DrzavaID = model.Grad.DrzavaID;
                g.PostanskiBroj = model.Grad.PostanskiBroj;
                _context.SaveChanges();
            }
            TempData["porukaSuccess"] = "Uspjesno je snimljen/dodat zapis";

            return RedirectToAction("Index");
            
        }
        
    }
}