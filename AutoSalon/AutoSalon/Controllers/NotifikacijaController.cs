using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Hubs;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.NotifikacijaViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Controllers
{
    public class NotifikacijaController : Controller
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubContext<SignalRHub> hubContext;
        public NotifikacijaController(ApplicationDbContext _db, 
                                      UserManager<ApplicationUser> _userManager,
                                      IHubContext<SignalRHub> _hubContext)
        {
            db = _db;
            userManager = _userManager;
            hubContext = _hubContext;
        }
        public IActionResult Index(int LogiraniKorisnikID)
        {
            int rola = -1;
            if(db.UserRoles.Where(w => w.UserId == LogiraniKorisnikID).FirstOrDefault()!=null)
             rola = db.UserRoles.Where(w => w.UserId == LogiraniKorisnikID).FirstOrDefault().RoleId;
            if (rola == 2)
            {
                NotifikacijaIndexVM model = new NotifikacijaIndexVM()
                {
                    KorisnikID = LogiraniKorisnikID,
                    Klijent=true,
                    Rows = db.Notifikacija.Where(y => y.PosiljaocID == LogiraniKorisnikID).Select(x => new NotifikacijaIndexVM.Row()
                    {
                        NotifikacijaID = x.NotifikacijaID,
                        DatumKreiranja = x.DatumKreiranja,
                        Posiljaoc = x.Posiljaoc.UserName,
                        Sadrzaj = x.Sadrzaj,
                        Status = x.Status
                    }).ToList()
                };
                return PartialView(model);

            }
            else
            {
                NotifikacijaIndexVM model = new NotifikacijaIndexVM()
                {
                    KorisnikID = LogiraniKorisnikID,
                    Klijent=false,
                    Rows = db.Notifikacija.Where(y => y.PrimalacID == LogiraniKorisnikID).Select(x => new NotifikacijaIndexVM.Row()
                    {
                        NotifikacijaID = x.NotifikacijaID,
                        DatumKreiranja = x.DatumKreiranja,
                        Posiljaoc = x.Posiljaoc.UserName,
                        Sadrzaj = x.Sadrzaj,
                        Status = x.Status
                    }).ToList()
                };
                return PartialView(model);
            }
            
            
        }

        public int  GetBrojNotifikacija(int KorisnikID)
        {
            if (db.UserRoles.Where(w => w.UserId == KorisnikID).FirstOrDefault() != null)
            {
                int rola = db.UserRoles.Where(w => w.UserId == KorisnikID).FirstOrDefault().RoleId;
                if (rola == 2)
                    return db.Notifikacija.Count(x => x.PosiljaocID == KorisnikID && x.Status == true);
                else return db.Notifikacija.Count(x => x.PrimalacID == KorisnikID && x.Status == false);
            }
            else
            { return db.Notifikacija.Count(x => x.PrimalacID == KorisnikID && x.Status == false); }

        }



        public async Task<IActionResult> OznaciKaoProcitano(int NotifikacijaID)
        {
            Notifikacija notifikacija = db.Notifikacija.FirstOrDefault(x => x.NotifikacijaID == NotifikacijaID);
            db.Notifikacija.Update(notifikacija);
            notifikacija.Status = true;

            await db.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
    }
}