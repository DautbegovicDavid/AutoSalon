using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;




namespace AutoSalon.Controllers
{
    public class DrzavaController : Controller
    {
        public ApplicationDbContext _context;
        public DrzavaController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            List<DrzavaVM> podaci = _context.Drzava.Select(x => new DrzavaVM
            {
                DrzavaID = x.DrzavaID,
                Naziv = x.Naziv

            }).ToList();

            ViewData["drzave"] = podaci;

            return View();
        }

        public IActionResult Izbrisi(int id)
        {
            Drzava d = _context.Drzava.SingleOrDefault(x => x.DrzavaID == id);

            if (d == null)
                return View("Error");

            _context.Remove(d);
            _context.SaveChanges();

            return Redirect("/Drzava/Index");
        }
        public IActionResult Dodaj()
        {
            return View();
        }
       
        public IActionResult Snimi(int DrzavaID, string Naziv)
        {
            Drzava d = _context.Drzava.Find(DrzavaID);

            if (d == null)
            {
                d = new Drzava { Naziv = Naziv };
                _context.Add(d);
                _context.SaveChanges();
            }
            else
            {
                d.Naziv = Naziv;
                _context.SaveChanges();
            }

            return Redirect("/Drzava/index");
        }
        public IActionResult Uredi(int id)
        {
            Drzava d = _context.Drzava.Find(id);
            ViewData["kljuc"] = d;
            return View();
        }


    }
}

