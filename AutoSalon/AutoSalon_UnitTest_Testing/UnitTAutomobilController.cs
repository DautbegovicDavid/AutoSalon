using AutoSalon.Controllers;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels;
using AutoSalon.Models.ViewModels.AutomobilViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AutoSalon_UnitTest_Testing
{
    [TestClass]
    public class UnitTAutomobilController
    {
        public  IHostingEnvironment he;

        //Pomocna klasa za testiranje Index akcije
        public class RowIndex
        {
            public int AutomobilID { get; set; }
            public string Model { get; set; }
            public string Proizvodjac { get; set; }
            public int GodinaProizvodnje { get; set; }
            public string Boja { get; set; }
            public string SlikaURL { get; set; }
           
        }




        [TestMethod]
        public void Index_Model_Automobil()
        {


            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            List<Automobil> ocekivani = applicationDbContext.Automobil.Where(x => x.ProizvodjacID == 1).ToList();

            AutomobilController ac = new AutomobilController(applicationDbContext,he);
            ViewResult vr = ac.Index(1,"") as ViewResult;

           AutomobilIndexVM model = vr.Model as AutomobilIndexVM;
         
            Assert.AreEqual(ocekivani.Count,model.Rows.Count);
             
        }


        [TestMethod]
        public void Index_Model_List_Automobil()
        {

            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            AutomobilController ac = new AutomobilController(applicationDbContext, he);

            List<Automobil> automobili = applicationDbContext.Automobil.Include(s=> s.Proizvodjac).Where(x => x.ProizvodjacID == 1).ToList();
            List<RowIndex> ocekivani = new List<RowIndex>();

            //Priprema liste ocekivani 
            foreach (Automobil a in automobili)
            {

                ocekivani.Add(new RowIndex
                {
                    AutomobilID = a.AutomobilID,
                    Boja = a.Boja,
                    Proizvodjac=a.Proizvodjac.Naziv,
                    GodinaProizvodnje = a.GodinaProizvodnje,
                    Model = a.Model,
                    SlikaURL = a.SlikaURL
                });
            }

            ViewResult vr = ac.Index(1, "") as ViewResult;

            AutomobilIndexVM model = vr.Model as AutomobilIndexVM;
            List<RowIndex> rezultat = new List<RowIndex>();

            //Priprema liste rezultat 
            foreach (AutomobilIndexVM.Row a in model.Rows)
            {

                rezultat.Add(new RowIndex
                {
                    AutomobilID = a.AutomobilID,
                    Boja = a.Boja,
                    Proizvodjac = a.Proizvodjac,
                    GodinaProizvodnje = a.GodinaProizvodnje,
                    Model = a.Model,
                    SlikaURL = a.SlikaURL
                });
            }


            CollectionAssert.AreEqual(ocekivani, rezultat,
                            Comparer<RowIndex>.Create(
                                (prvi, drugi) => prvi.AutomobilID == drugi.AutomobilID
                                              && prvi.Model == drugi.Model
                                              && prvi.Boja == drugi.Boja
                                              && prvi.GodinaProizvodnje == drugi.GodinaProizvodnje
                                              && prvi.Proizvodjac == drugi.Proizvodjac
                                              && prvi.SlikaURL == drugi.SlikaURL ? 0 : 1));
        }


        [TestMethod]
        public void Index_Model_List_Proizvodjac_Model_Automobil()
        {

            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            AutomobilController ac = new AutomobilController(applicationDbContext, he);

            List<Automobil> automobili = applicationDbContext.Automobil.Include(s => s.Proizvodjac).Where(x => x.ProizvodjacID == 1 && x.Model=="X5").ToList();
            List<RowIndex> ocekivani = new List<RowIndex>();

            
            foreach (Automobil a in automobili)
            {

                ocekivani.Add(new RowIndex
                {
                    AutomobilID = a.AutomobilID,
                    Boja = a.Boja,
                    Proizvodjac = a.Proizvodjac.Naziv,
                    GodinaProizvodnje = a.GodinaProizvodnje,
                    Model = a.Model,
                    SlikaURL = a.SlikaURL
                });
            }

            ViewResult vr = ac.Index(1, "X5") as ViewResult;

            AutomobilIndexVM model = vr.Model as AutomobilIndexVM;
            
            List<RowIndex> rezultat = new List<RowIndex>();

            
            foreach (AutomobilIndexVM.Row a in model.Rows)
            {

                rezultat.Add(new RowIndex
                {
                    AutomobilID = a.AutomobilID,
                    Boja = a.Boja,
                    Proizvodjac = a.Proizvodjac,
                    GodinaProizvodnje = a.GodinaProizvodnje,
                    Model = a.Model,
                    SlikaURL = a.SlikaURL
                });
            }


            CollectionAssert.AreEqual(ocekivani, rezultat,
                            Comparer<RowIndex>.Create(
                                (prvi, drugi) => prvi.AutomobilID == drugi.AutomobilID
                                              && prvi.Model == drugi.Model
                                              && prvi.Boja == drugi.Boja
                                              && prvi.GodinaProizvodnje == drugi.GodinaProizvodnje
                                              && prvi.Proizvodjac == drugi.Proizvodjac
                                              && prvi.SlikaURL == drugi.SlikaURL ? 0 : 1));
        }
        [TestMethod]
        public void Index_Model_Count_BMW()
        {

            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            AutomobilController ac = new AutomobilController(applicationDbContext, he);

            int  OcekivanBrojAutomobila = applicationDbContext.Automobil.Include(s => s.Proizvodjac).Where(x => x.ProizvodjacID == 1).Count();
            
            ViewResult vr = ac.Index(1, "") as ViewResult;

            AutomobilIndexVM model = vr.Model as AutomobilIndexVM;
            

            int DobijeniBrojAutomobila = model.Rows.Count();
            
            

            Assert.AreEqual(OcekivanBrojAutomobila, DobijeniBrojAutomobila);
            
        }


    }

    [TestClass]
    public class UnitIznajmiAutomobilController
    {
        public IHostingEnvironment he;
        [TestMethod]
        public void IndexView_Count_Dostupni_poGradu()
        {
            //ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();

            IznajmiAutomobilController iac = new IznajmiAutomobilController(applicationDbContext,he);
            ViewResult vr = iac.Index("Mostar","da", null, null, null, null, null, null) as ViewResult;
            AutomobilRent model = vr.Model as AutomobilRent;
            int DobijeniRez=model.auta.Count();
            int OcekivaniRez = applicationDbContext.Automobil.Include(i => i.AutomobilDetalji).Where(w => w.AutomobilDetalji.Poslovnica.Grad.Naziv.ToString() == "Mostar").Count();
            Assert.AreEqual(OcekivaniRez, DobijeniRez);
            
        }
        [TestMethod]
        public void IndexView_Count_Dostupni_poGradu_poProizvodjac()
        {
            //ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();

            IznajmiAutomobilController iac = new IznajmiAutomobilController(applicationDbContext, he);
            ViewResult vr = iac.Index("Mostar", "da", 1, null, null, null, null, null) as ViewResult;
            AutomobilRent model = vr.Model as AutomobilRent;
            int DobijeniRez = model.auta.Count();
            int OcekivaniRez = applicationDbContext.Automobil.Include(i => i.AutomobilDetalji).Where(w => w.AutomobilDetalji.Poslovnica.Grad.Naziv.ToString() == "Mostar" && w.ProizvodjacID==1).Count();
            Assert.AreEqual(OcekivaniRez, DobijeniRez);

        }

    }

    [TestClass]
    public class UnitKupiAutomobilController
    {
        public IHostingEnvironment he;

        [TestMethod]
        public void VozilaView_Count_Nova_BMW_X6()
        {

        ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();

            KupiAutomobilController kac = new KupiAutomobilController(applicationDbContext, he);
            ViewResult vr = kac.Vozila("NovaVozila", 1,"X6","Euro 6","Dizel","Automatic","4x4",null,null,null,null,null,null,null,null,null) as ViewResult;
            AutomobilKupiVM model = vr.Model as AutomobilKupiVM;
            int dobijeniRez = model.automobili1.Count();
            int ocekivaniRez = applicationDbContext.Automobil.Include(i=>i.AutomobilDetalji).Where(w => w.Novo == true && w.Model=="X6").Count();
            Assert.AreEqual(ocekivaniRez, dobijeniRez);
        }
       
    }

    [TestClass]
    public class UnitGradController
    {
        public class GradPomocna
        {
            public int GradID { get; set; }
            public string Naziv { get; set; }
            public string PostanskiBroj { get; set; }
            public string Drzava { get; set; }
            


        }
        [TestMethod]
        public void UrediDodaj_Model_Grad()
        {
            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            Grad ocekivani = applicationDbContext.Grad.Where(x => x.GradID == 1).FirstOrDefault();

            GradController gc = new GradController(applicationDbContext);
            ViewResult vr = gc.UrediDodaj(1) as ViewResult;

            GradDodajVM model = vr.Model as GradDodajVM;

            Assert.AreEqual(ocekivani.Naziv,model.Grad.Naziv);
        }
        [TestMethod]
        public void Index_Model_List_Grad()
        {
            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            List<Grad> gradovi = applicationDbContext.Grad.Include(i=>i.Drzava).ToList();
            List<GradPomocna> ocekivani = new List<GradPomocna>();
            foreach(var x in gradovi)
            {
                ocekivani.Add(new GradPomocna
                {
                    GradID=x.GradID,
                    Naziv=x.Naziv,
                    PostanskiBroj=x.PostanskiBroj,
                    Drzava=x.Drzava.Naziv
                });
            }

            GradController gc = new GradController(applicationDbContext);
            ViewResult vr = gc.Index() as ViewResult;

            List<GradVM> model = vr.ViewData["gradovi"] as List<GradVM>;
            List<GradPomocna> rezultat = new List<GradPomocna>();

            foreach (var x in model)
            {
                rezultat.Add(new GradPomocna
                {
                    GradID = x.GradID,
                    Naziv = x.Naziv,
                    PostanskiBroj = x.PostanskiBroj,
                    Drzava = x.Drzava
                });
            }

            CollectionAssert.AreEqual(ocekivani, rezultat,
                Comparer<GradPomocna>.Create((prvi, drugi) => prvi.GradID == drugi.GradID &&
              prvi.Naziv == drugi.Naziv && prvi.PostanskiBroj == drugi.PostanskiBroj && prvi.Drzava==drugi.Drzava? 0 : 1));
        }

    }
    [TestClass]
    public class UnitDrzavaController
    {
        public class DrzavaPomocna
        {
            public int DrzavaID { get; set; }
            public string Naziv { get; set; }

        }
        [TestMethod]
        public void UrediDodaj_Model_Drzava()
        {
            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            Drzava ocekivani = applicationDbContext.Drzava.Where(x => x.DrzavaID == 1).FirstOrDefault();

            DrzavaController dc = new DrzavaController(applicationDbContext);
            ViewResult vr = dc.UrediDodaj(1) as ViewResult;

            DrzavaDodajVM model = vr.Model as DrzavaDodajVM;

            Assert.AreEqual(ocekivani.DrzavaID, model.Drzava.DrzavaID);
        }
        [TestMethod]
        public void Index_Model_List_Drzava()
        {
            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            List<Drzava> gradovi = applicationDbContext.Drzava.ToList();
            List<DrzavaPomocna> ocekivani = new List<DrzavaPomocna>();
            foreach (var x in gradovi)
            {
                ocekivani.Add(new DrzavaPomocna
                {
                    DrzavaID = x.DrzavaID,
                    Naziv = x.Naziv,
                  
                });
            }

            DrzavaController dc = new DrzavaController(applicationDbContext);
            ViewResult vr = dc.Index() as ViewResult;

            DrzavaVM model = vr.Model as DrzavaVM;
            List<DrzavaPomocna> rezultat = new List<DrzavaPomocna>();

            foreach (var x in model.podaci)
            {
                rezultat.Add(new DrzavaPomocna
                {
                    DrzavaID = x.DrzavaID,
                    Naziv = x.Naziv,
                    
                });
            }

            CollectionAssert.AreEqual(ocekivani, rezultat,
                Comparer<DrzavaPomocna>.Create((prvi, drugi) => prvi.DrzavaID == drugi.DrzavaID &&
              prvi.Naziv == drugi.Naziv  ? 0 : 1));
        }

    }




}
