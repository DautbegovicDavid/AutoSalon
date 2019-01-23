using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoSalon.Data;
using AutoSalon.Hubs;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.NotifikacijaViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
            NotifikacijaIndexVM model = new NotifikacijaIndexVM()
            {
                KorisnikID = LogiraniKorisnikID,
                Rows = db.Notifikacija.Where(y => y.PrimalacID == LogiraniKorisnikID).Select(x => new NotifikacijaIndexVM.Row() {
                    NotifikacijaID=x.NotifikacijaID,
                    DatumKreiranja=x.DatumKreiranja,
                    Posiljaoc=x.Posiljaoc.UserName,
                    Sadrzaj=x.Sadrzaj,
                    Status=x.Status
                }).ToList()
            };
            return View(model);
        }

        public int  GetBrojNotifikacija(int KorisnikID)
        {
            return db.Notifikacija.Count(x => x.PrimalacID == KorisnikID);
        }

        public async Task<IActionResult> OznaciKaoProcitano(int NotifikacijaID)
        {
            Notifikacija notifikacija = db.Notifikacija.FirstOrDefault(x => x.NotifikacijaID == NotifikacijaID);
            db.Notifikacija.Update(notifikacija);
            notifikacija.Status = true;

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { LogiraniKorisnikID = userManager.GetUserId(HttpContext.User) });
        }
    }
}