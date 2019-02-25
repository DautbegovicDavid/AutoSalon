using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.KorisnikViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class KorisnikController : Controller
    {
        private ApplicationDbContext db;
        public KorisnikController(ApplicationDbContext _db)
        {
            db = _db;
        }


        //Funkcija koja priprema listu rola
        public List<SelectListItem> PripremaListItemRole()
        {
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value=string.Empty,
                    Text="(Svi korisnici)"
                }
            };
            listItems.AddRange(db.Roles.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }));

        

            return listItems;
        }


        public IActionResult Index(int? RoleID,string  kIme)
        {
            KorisnikIndexVM model = new KorisnikIndexVM();
            model.Role = PripremaListItemRole();
            if (kIme != null)
                kIme = kIme.ToLower();


            model.Rows = db.Users.Join(db.UserRoles, u => u.Id, ur => ur.UserId, 
                                                                       (u, ur) => new
                                                                        {
                                                                            korisnikID = u.Id,
                                                                            imePrezime = u.Ime + ' ' + u.Prezime,
                                                                            grad = u.Grad.Naziv,
                                                                            email = u.Email,
                                                                            korisnickoIme = u.UserName,
                                                                            datumRegistracije=u.DatumRegistracije,
                                                                            datumRodjenja=u.DatumRodjenja,
                                                                           slikaURL =u.SlikaURL,
                                                                            tipKorisnika = (db.Roles.Where(y => y.Id == ur.RoleId).FirstOrDefault().Name),
                                                                            roleID = ur.RoleId
                                                                        })
                                 .Where(g => (g.roleID == RoleID || RoleID == null) && (g.korisnickoIme.ToLower().Contains(kIme) || kIme==null)).Select(x => new KorisnikIndexVM.Row()
                                 {
                                     KorisnikID = x.korisnikID,
                                     ImePrezime = x.imePrezime,
                                     Grad = x.grad,
                                     Email = x.email,
                                     KorisnickoIme = x.korisnickoIme,
                                     DatumRegistracije=x.datumRegistracije,
                                     SlikaURL=x.slikaURL,
                                     DatumRodjenja=x.datumRodjenja,
                                     TipKorisnika =x.tipKorisnika
                                 }).ToList();
      
            return View(model);
        }

        public IActionResult Detalji(int KorisnikID)
        {
            ApplicationUser user = db.Users.Include(y=> y.Grad).FirstOrDefault(x => x.Id == KorisnikID);
            int RoleID = db.UserRoles.FirstOrDefault(x => x.UserId == user.Id).RoleId;

            KorisnikDetaljiVM model = new KorisnikDetaljiVM()
            {
                KorisnikID=KorisnikID,
                Ime=user.Ime,
                Prezime=user.Prezime,
                DatumRodjenja=user.DatumRodjenja.ToShortDateString(),
                Grad=user.GradID!=null?user.Grad.Naziv:"",
                Adresa =user.Adresa,
                KontaktTelefon=user.PhoneNumber,
                BrojKupovina=db.Kupovina.Count(z=> z.KlijentID==user.Id),
                BrojIznajmljivanja = db.RezervacijaRentanja.Count(z => z.KlijentID == user.Id),
                SlikaURL =user.SlikaURL,
                TipKorisnika = db.Roles.Where(y => y.Id == RoleID).FirstOrDefault().Name

            };
            return View(model);
        }

        public async Task<IActionResult> DodijelaRole(int KorisnikID)
        {
            int userID = KorisnikID;
            int roleID = db.Roles.Where(x => x.Name == "Uposlenik").FirstOrDefault().Id;
           var UserRole= db.UserRoles.Where(x => x.UserId == userID).FirstOrDefault();
            db.UserRoles.Remove(UserRole);

            IdentityUserRole<int> newUserRole = new IdentityUserRole<int>
            {
                RoleId = roleID,
                UserId = userID,
                
            };
            db.UserRoles.Add(newUserRole);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Detalji), new { KorisnikID = userID });
        }
        public async Task<IActionResult> UkloniRole(int KorisnikID)
        {
            int userID = KorisnikID;
            int roleID = db.Roles.Where(x => x.Name == "Klijent").FirstOrDefault().Id;
            var UserRole = db.UserRoles.Where(x => x.UserId == userID).FirstOrDefault();
            db.UserRoles.Remove(UserRole);

            IdentityUserRole<int> newUserRole = new IdentityUserRole<int>
            {
                RoleId = roleID,
                UserId = userID,

            };
            db.UserRoles.Add(newUserRole);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Detalji), new { KorisnikID = userID });
        }
    }
}