using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class PoslovnicaController : Controller
    {
        private ApplicationDbContext _context;

        public PoslovnicaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var poslovnice = _context.Poslovnice.Include(p => p.Grad).ToListAsync();
            return View(await poslovnice);
        }

        //Get Dodaj
        public IActionResult Dodaj()
        {
            ViewData["GradID"] = new SelectList(_context.Gradovi, "GradID", "Naziv");
            return View();
        }

        //Post Dodaj
        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("PoslovnicaID,GradID,Adresa,Naziv,KontaktTelefon")]Poslovnica poslovnica)
        {
            if (ModelState.IsValid)
            {
                _context.Poslovnice.Add(poslovnica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GradID"] = new SelectList(_context.Gradovi, "GradID", "Naziv", poslovnica.GradID);
            return View(poslovnica);
        }
    }
}