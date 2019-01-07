using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.KorisnikViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
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


        public IActionResult Index(int? RoleID)
        {
            KorisnikIndexVM model = new KorisnikIndexVM();
            model.Role = PripremaListItemRole();

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
                                 .Where(g => g.roleID == RoleID || RoleID == null).Select(x => new KorisnikIndexVM.Row()
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

            KorisnikDetaljiVM model = new KorisnikDetaljiVM()
            {
                KorisnikID=KorisnikID,
                Ime=user.Ime,
                Prezime=user.Prezime,
                DatumRodjenja=user.DatumRodjenja.ToShortDateString(),
                Grad=user.Grad.Naziv,
                Adresa =user.Adresa,
                KontaktTelefon=user.PhoneNumber
            };
            return View(model);
        }
    }
}