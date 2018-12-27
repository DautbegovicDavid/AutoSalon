using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models.ViewModels;
using AutoSalon.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Izbrisi(int id)
        {
            Grad g = _context.Grad.SingleOrDefault(x => x.GradID == id);

            if (g == null)
                return View("Error");

            _context.Remove(g);
            _context.SaveChanges();

            return Redirect("/grad/index");
        }
        public IActionResult Dodaj()
        {
            List<Drzava> podaci = _context.Drzava.ToList();
            ViewData["kljuc"] = podaci;
            return View();
        }

        public IActionResult Snimi(int gradID, string Naziv,int DrzavaID,string PostanskiBroj)
        {
            Grad g = _context.Grad.Find(gradID);

            if (g == null)
            {
                g = new Grad { Naziv = Naziv,DrzavaID=DrzavaID,PostanskiBroj=PostanskiBroj };
                _context.Add(g);
                _context.SaveChanges();
            }
            else
            {
                g.Naziv = Naziv;
                g.DrzavaID = DrzavaID;
                g.PostanskiBroj = PostanskiBroj;
                _context.SaveChanges();
            }

            return Redirect("/grad/index");
        }
        public IActionResult Uredi(int id)
        {
            Grad g = _context.Grad.Find(id);
            List<Drzava> drzave = _context.Drzava.ToList();
            ViewData["kljuc"] = g;
            ViewData["kljuc1"] = drzave;

            return View();
        }
    }
}