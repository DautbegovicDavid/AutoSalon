using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoSalon.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AutoSalon.Data;

namespace AutoSalon.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public int getIDProizvodjac(string ime)
        {
            
            Proizvodjac p = db.Proizvodjac.Where(w => w.Naziv.ToString() == ime.ToString()).FirstOrDefault();
            if (p != null)
             return p.ProizvodjacID;
            else return 0;
            
        }
       
        public IActionResult Index()
        {
            int x = 0;
            int merc = getIDProizvodjac("Mercedes");
            int vw = getIDProizvodjac("Volkswagen");
            int bmw = getIDProizvodjac("BMW");
            int audi = getIDProizvodjac("Audi");
            int toy = getIDProizvodjac("Toyota");
            int hyu = getIDProizvodjac("Hyundai");
            int peu = getIDProizvodjac("Peugeot");
            int cit = getIDProizvodjac("Citroen");



            if (User.Identity.IsAuthenticated)
            {
                string klijentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Int32.TryParse(klijentID.ToString(), out x);
            }
            
            ViewData["x"]= x;
            ViewData["merc"] = merc;
            ViewData["vw"] = vw;
            ViewData["bmw"] = bmw;
            ViewData["audi"] = audi;
            ViewData["toy"] = toy;
            ViewData["hyu"] = hyu;
            ViewData["peu"] = peu;
            ViewData["cit"] = cit;



            return View(x); 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
