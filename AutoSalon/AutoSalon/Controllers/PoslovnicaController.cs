using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class PoslovnicaController : Controller
    {
        private ApplicationDbContext _context;
        private IHostingEnvironment he;

        public PoslovnicaController(ApplicationDbContext context, IHostingEnvironment _he)
        {
            _context = context;
            he = _he;
        }

        //Index
        public IActionResult Index(int ? GradID)
        {
            PoslovnicaIndexVM model = new PoslovnicaIndexVM();
            model.Gradovi = PripremaListItemGradovi();
            model.Gradovi.FirstOrDefault().Text = "(sve poslovnice)";
            if (GradID != null) {
                model.Rows = _context.Poslovnica.Where(y=> y.GradID==GradID).Select(x => new PoslovnicaIndexVM.Row()
                {
                    PoslovnicaId = x.PoslovnicaID,
                    Naziv = x.Naziv,
                    Grad = x.Grad.Naziv,
                    Adresa = x.Adresa,
                    KontaktTelefon = x.KontaktTelefon,
                    SlikaUrl = x.SlikaURL
                }).ToList();
            }
            else
            {
                model.Rows = _context.Poslovnica.Select(x => new PoslovnicaIndexVM.Row()
                {
                    PoslovnicaId = x.PoslovnicaID,
                    Naziv = x.Naziv,
                    Grad = x.Grad.Naziv,
                    Adresa = x.Adresa,
                    KontaktTelefon = x.KontaktTelefon,
                    SlikaUrl = x.SlikaURL
                }).ToList();
            }

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
            listItems.AddRange(_context.Grad.Select(x => new SelectListItem()
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
        public async Task<IActionResult> Dodaj(PoslovnicaDodajVM model,IFormFile SlikaUrl)
        {
            Poslovnica poslovnica = new Poslovnica();
            poslovnica.GradID = model.GradID;
            poslovnica.Naziv = model.Naziv;
            poslovnica.Adresa = model.Adresa;
            poslovnica.KontaktTelefon = model.KontaktTelefon;
            poslovnica.SlikaURL =SlikaUrl.FileName;

            var filePath = Path.Combine(he.WebRootPath + "\\images\\Poslovnice", SlikaUrl.FileName);
            SlikaUrl.CopyTo(new FileStream(filePath, FileMode.Create));

            if (ModelState.IsValid)
            {
                _context.Poslovnica.Add(poslovnica);
                 await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            model.Gradovi = PripremaListItemGradovi();

            return View(model);
        }



        //Get Uredi
        public IActionResult Uredi(int  PoslovnicaID)
        {

            Poslovnica poslovnica = _context.Poslovnica.FirstOrDefault(x => x.PoslovnicaID == PoslovnicaID);

            PoslovnicaUrediVM model = new PoslovnicaUrediVM()
            {
                Gradovi = PripremaListItemGradovi(),
                PoslovnicaID=PoslovnicaID,
                GradID = poslovnica.GradID,
                Adresa = poslovnica.Adresa,
                Naziv = poslovnica.Naziv,
                KontaktTelefon = poslovnica.KontaktTelefon,
                SlikaURL = poslovnica.SlikaURL
            };

            return View( model);
        }

        //Post Uredi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Uredi(PoslovnicaUrediVM model)
        {
            Poslovnica poslovnica = _context.Poslovnica.FirstOrDefault(x => x.PoslovnicaID == model.PoslovnicaID);
            poslovnica.GradID = model.GradID;
            poslovnica.KontaktTelefon = model.KontaktTelefon;
            poslovnica.Adresa = model.Adresa;
            poslovnica.Naziv = model.Naziv;
            poslovnica.SlikaURL = model.SlikaURL;

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
            Poslovnica poslovnica = _context.Poslovnica.Include(y=> y.Grad).FirstOrDefault(x => x.PoslovnicaID == PoslovnicaID);

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
            Poslovnica poslovnica =  _context.Poslovnica.Include(y=> y.Grad).FirstOrDefault(x=> x.PoslovnicaID==PoslovnicaID);

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
            Poslovnica poslovnica =await _context.Poslovnica.SingleOrDefaultAsync(p=> p.PoslovnicaID==PoslovnicaID);
            _context.Poslovnica.Remove(poslovnica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}