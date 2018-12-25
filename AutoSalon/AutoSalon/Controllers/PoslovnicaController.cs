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
    public class PoslovnicaController : Controller
    {
        private ApplicationDbContext _context;

        public PoslovnicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Index
        public IActionResult Index()
        {
            PoslovnicaIndexVM model = new PoslovnicaIndexVM()
            {
                Rows=_context.Poslovnice.Select(x=> new PoslovnicaIndexVM.Row() {
                    PoslovnicaId=x.PoslovnicaID,
                    Naziv = x.Naziv,
                    Grad = x.Grad.Naziv,
                    Adresa=x.Adresa,
                    KontaktTelefon = x.KontaktTelefon,
                    SlikaUrl=x.SlikaURL
                }).ToList()
            };          
            return View( model);
        }


        //Funkcija koja priprema listu gradova
        public List<SelectListItem> PripremaListItemGradovi()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Odaberite grad)"
                }
            };
            listItems.AddRange(_context.Gradovi.Select(x => new SelectListItem()
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }));

            return listItems;
        }



        //Get Dodaj
        public IActionResult Dodaj()
        {
            PoslovnicaDodajVM model = new PoslovnicaDodajVM();
            model.Gradovi = PripremaListItemGradovi();
          
            return View(model);
        }

        //Post Dodaj
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj(PoslovnicaDodajVM model)
        {
            Poslovnica poslovnica = new Poslovnica();
            poslovnica.GradID = model.GradID;
            poslovnica.Naziv = model.Naziv;
            poslovnica.Adresa = model.Adresa;
            poslovnica.KontaktTelefon = model.KontaktTelefon;
            poslovnica.SlikaURL = model.SlikaUrl;

            if (ModelState.IsValid)
            {
                _context.Poslovnice.Add(poslovnica);
                 await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            model.Gradovi = PripremaListItemGradovi();

            return View(poslovnica);
        }



        //Get Uredi
        public IActionResult Uredi(int  PoslovnicaID)
        {

            Poslovnica poslovnica = _context.Poslovnice.FirstOrDefault(x => x.PoslovnicaID == PoslovnicaID);

            PoslovnicaUrediVM model = new PoslovnicaUrediVM()
            {
                Gradovi = PripremaListItemGradovi(),
                PoslovnicaID=PoslovnicaID,
                GradID = poslovnica.GradID,
                Adresa = poslovnica.Adresa,
                Naziv = poslovnica.Naziv,
                KontaktTelefon = poslovnica.KontaktTelefon,
                SlikaUrl = poslovnica.SlikaURL
            };

            return View( model);
        }

        //Post Uredi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Uredi(PoslovnicaUrediVM model)
        {
            Poslovnica poslovnica = _context.Poslovnice.FirstOrDefault(x => x.PoslovnicaID == model.PoslovnicaID);
            poslovnica.GradID = model.GradID;
            poslovnica.KontaktTelefon = model.KontaktTelefon;
            poslovnica.Adresa = model.Adresa;
            poslovnica.Naziv = model.Naziv;
            poslovnica.SlikaURL = model.SlikaUrl;

            if (ModelState.IsValid)
            {
                _context.Update(poslovnica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            model.Gradovi = PripremaListItemGradovi();

            return View(poslovnica);
        }




        //Detalji
        public IActionResult Detalji(int PoslovnicaID)
        {
            Poslovnica poslovnica = _context.Poslovnice.Include(y=> y.Grad).FirstOrDefault(x => x.PoslovnicaID == PoslovnicaID);

            PoslovnicaDetaljiVM model = new PoslovnicaDetaljiVM()
            {
                PoslovnicaID=PoslovnicaID,
                Naziv=poslovnica.Naziv,
                Adresa=poslovnica.Adresa,
                Grad=poslovnica.Grad.Naziv,
                KontaktTelefon=poslovnica.KontaktTelefon,
                SlikaUrl=poslovnica.SlikaURL
            };

            return View( model);
        }



        //Get Ukloni
        public IActionResult Ukloni(int PoslovnicaID)
        {
            Poslovnica poslovnica =  _context.Poslovnice.Include(y=> y.Grad).FirstOrDefault(x=> x.PoslovnicaID==PoslovnicaID);

            PoslovnicaUkloniVM model = new PoslovnicaUkloniVM()
            {
                PoslovnicaID=PoslovnicaID,
                Naziv=poslovnica.Naziv,
                Grad=poslovnica.Grad.Naziv,
                Adresa=poslovnica.Adresa,
                KontaktTelefon=poslovnica.KontaktTelefon,

            };
            return View(model);
        }

        //Post Ukloni
        [HttpPost,ActionName("Ukloni")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UkloniPotvrda(int PoslovnicaID)
        {
            Poslovnica poslovnica =await _context.Poslovnice.SingleOrDefaultAsync(p=> p.PoslovnicaID==PoslovnicaID);
            _context.Poslovnice.Remove(poslovnica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}