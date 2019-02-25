using AutoSalon.Controllers;
using AutoSalon.Data;
using AutoSalon.Models;
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

    }


   


}
