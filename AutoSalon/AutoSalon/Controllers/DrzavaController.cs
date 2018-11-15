using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoSalon.Data;
using AutoSalon.Models.ViewModels;
using AutoSalon.Models;




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
            List<DrzavaVM> podaci = _context.Drzave.Select(x => new DrzavaVM
            {
                DrzavaID = x.DrzavaID,
                Naziv = x.Naziv

            }).ToList();

            ViewData["drzave"] = podaci;

            return View();
        }

        public IActionResult Izbrisi(int id)
        {
            Drzava d = _context.Drzave.SingleOrDefault(x => x.DrzavaID == id);

            if (d == null)
                return View("Error");

            _context.Remove(d);
            _context.SaveChanges();

            return Redirect("/Drzava/index");
        }
        public IActionResult Dodaj()
        {
            return View();
        }

        public IActionResult Snimi(int DrzavaID, string Naziv)
        {
            Drzava d = _context.Drzave.Find(DrzavaID);

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
            Drzava d = _context.Drzave.Find(id);
            ViewData["kljuc"] = d;
            return View();
        }


    }
}

