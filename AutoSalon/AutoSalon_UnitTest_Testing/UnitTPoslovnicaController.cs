using AutoSalon.Controllers;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.PoslovnicaViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSalon_UnitTest_Testing
{
  
        [TestClass]
        public class UnitTPoslovnicaController
    {
            public IHostingEnvironment he;

            //Pomocna klasa za testiranje Index akcije
            public class RowIndex
            {
        

            public int PoslovnicaId { get; set; }
            public string Grad { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public string KontaktTelefon { get; set; }
            public string SlikaUrl { get; set; }
        }


            [TestMethod]
            public void Index_Model_Poslovnica()
            {


                ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
                List<Poslovnica> ocekivani = applicationDbContext.Poslovnica.Where(x => x.GradID == 1).ToList();

                PoslovnicaController pc = new PoslovnicaController(applicationDbContext, he);
                ViewResult vr = pc.Index(1, "", "") as ViewResult;

                PoslovnicaIndexVM model = vr.Model as PoslovnicaIndexVM;

                Assert.AreEqual(ocekivani.Count, model.Rows.Count);

            }

            [TestMethod]
            public void Index_Model_List_Poslovnica()
            {

                ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
                PoslovnicaController pc = new PoslovnicaController(applicationDbContext, he);

                List<Poslovnica> poslovnice = applicationDbContext.Poslovnica.Include(s => s.Grad).Where(x => x.GradID == 1).ToList();
                List<RowIndex> ocekivani = new List<RowIndex>();

                //Priprema liste ocekivani 
                foreach (Poslovnica p in poslovnice)
                {

                    ocekivani.Add(new RowIndex
                    {
                        PoslovnicaId = p.PoslovnicaID,
                        Grad = p.Grad.Naziv,
                        Adresa = p.Adresa,
                        Naziv = p.Naziv,
                        KontaktTelefon = p.KontaktTelefon,
                        SlikaUrl = p.SlikaURL
                    });
                }

                ViewResult vr = pc.Index(1, "", "") as ViewResult;

                PoslovnicaIndexVM model = vr.Model as PoslovnicaIndexVM;
                List<RowIndex> rezultat = new List<RowIndex>();

                //Priprema liste rezultat 
                foreach (PoslovnicaIndexVM.Row p in model.Rows)
                {

                    rezultat.Add(new RowIndex
                    {
                        PoslovnicaId = p.PoslovnicaId,
                        Grad = p.Grad,
                        Adresa = p.Adresa,
                        Naziv = p.Naziv,
                        KontaktTelefon = p.KontaktTelefon,
                        SlikaUrl = p.SlikaUrl
                    });
                }


                CollectionAssert.AreEqual(ocekivani, rezultat,
                                Comparer<RowIndex>.Create(
                                    (prvi, drugi) => prvi.PoslovnicaId == drugi.PoslovnicaId
                                               && prvi.Naziv == drugi.Naziv
                                               && prvi.Adresa == drugi.Adresa
                                               && prvi.Grad == drugi.Grad
                                               && prvi.KontaktTelefon == drugi.KontaktTelefon
                                               && prvi.SlikaUrl == drugi.SlikaUrl ? 0 : 1));
            }
        }
}
