using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autosalon.Models;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.AktivnostiViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class AktivnostiController : Controller
    {
        private ApplicationDbContext db;
        public AktivnostiController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public string getImePrezimeUposlenik(int ID)
        {
            string ipu = db.Users.SingleOrDefault(w => w.Id == ID).Ime.ToString() + " " + db.Users.SingleOrDefault(w => w.Id == ID).Prezime.ToString();
            return ipu;
        }
        public string getAutomobil(int ID)
        {
            Automobil a = db.Automobil.Include(i => i.Proizvodjac).Where(w=>w.AutomobilID==ID).FirstOrDefault();
            
            string ipu = a.Proizvodjac.Naziv.ToString() + " " + a.Model.ToString()
                +" "+ a.Boja.ToString() + " "+ a.GodinaProizvodnje.ToString();
            return ipu;
        }
        public string getImePoslovnice(int ID)
        {
            Poslovnica p = db.Poslovnica.Include(i => i.Grad.Drzava).Where(w => w.PoslovnicaID == ID).First();
            string naziv = db.Poslovnica.Include(i => i.Grad.Drzava).Where(w => w.PoslovnicaID == ID).FirstOrDefault().Grad.Drzava.Naziv.ToString() + ", " + db.Poslovnica.Include(i => i.Grad).Where(w => w.PoslovnicaID == ID).FirstOrDefault().Grad.Naziv.ToString() + "  " + db.Poslovnica.Where(w => w.PoslovnicaID == ID).FirstOrDefault().Adresa + " - " + db.Poslovnica.Where(w => w.PoslovnicaID == ID).FirstOrDefault().Naziv.ToString();
            return naziv;
        }
        public IActionResult Index()
        {
            AktivnostiIndexVM model = new AktivnostiIndexVM();
            int x = 0;
            string klijentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Int32.TryParse(klijentID.ToString(), out x);
            ApplicationUser u = db.Users.Include(i => i.Grad.Drzava).SingleOrDefault(s => s.Id == x);
            model.ImePrezime=u.Ime.ToString()+ " "+u.Prezime.ToString();
            if(u.Grad!=null)
            model.GradDrzava = u.Grad.Naziv.ToString() + " " + u.Grad.Drzava.Naziv.ToString();
            List<RezervacijaRentanje> rrs = db.RezervacijaRentanja.Where(w => w.KlijentID == x).ToList();
            List<RezervacijaKupovina> rks = db.RezervacijaKupovina.Where(w => w.KlijentID == x).ToList();
            model.rentanja= db.RezervacijaRentanja.Where(w => w.KlijentID == x).Select(s=>new AktivnostiIndexVM.Rentanja {

                datumKreiranja=s.DatumKreiranja,
                datumPreuzimanja=s.RezervacijaOd,
                datumVracanja=s.RezervacijaDo,
                Uposlenik = db.Users.SingleOrDefault(w => w.Id == s.UposlenikID).Ime.ToString() + " " + db.Users.SingleOrDefault(w => w.Id == s.UposlenikID).Prezime.ToString(),
                Poslovnica = db.Poslovnica.Include(i => i.Grad).SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Grad.Naziv.ToString() + "  " + db.Poslovnica.SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Adresa.ToString() + " - " + db.Poslovnica.SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Naziv.ToString(),
                Automobil= db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().Proizvodjac.Naziv.ToString() + " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().Model.ToString()+ " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().Boja.ToString() + " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().GodinaProizvodnje.ToString()

                //Automobil=getAutomobil(s.AutomobilID),
                //Uposlenik=getImePrezimeUposlenik(s.UposlenikID),
                //Poslovnica=getImePoslovnice(s.PoslovnicaID), /* db.Poslovnica.Include(i => i.Grad).SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Grad.Drzava.Naziv.ToString() + ", " +*/


            }).ToList();
            model.kupovine = db.RezervacijaKupovina.Where(w => w.KlijentID == x).Select(s => new AktivnostiIndexVM.Kupovine
            {
                datumKreiranja = s.DatumKreiranja,
                datumPreuzimanja = s.DatumPreuzimanja,
                Poslovnica=  db.Poslovnica.Include(i => i.Grad).SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Grad.Naziv.ToString() + "  " + db.Poslovnica.SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Adresa.ToString() + " - " + db.Poslovnica.SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Naziv.ToString(),
                Uposlenik = db.Users.SingleOrDefault(w => w.Id == s.UposlenikID).Ime.ToString() + " " + db.Users.SingleOrDefault(w => w.Id == s.UposlenikID).Prezime.ToString(),
                Automobil = db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().Proizvodjac.Naziv.ToString() + " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().Model.ToString() + " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().Boja.ToString() + " " + db.Automobil.Include(i => i.Proizvodjac).Where(w => w.AutomobilID == s.AutomobilID).FirstOrDefault().GodinaProizvodnje.ToString(),
                kompletiranaKupovina=s.KompletiranaKupovina

                //Automobil=getAutomobil(s.AutomobilID),
                //Uposlenik = getImePrezimeUposlenik(s.UposlenikID),
                //Poslovnica = getImePoslovnice(s.PoslovnicaID)
                /*db.Poslovnica.Include(i => i.Grad.Drzava).SingleOrDefault(w => w.PoslovnicaID == s.PoslovnicaID).Grad.Drzava.Naziv.ToString() + ", " +*/



            }).ToList();


            return View(model);
        }
    }
}