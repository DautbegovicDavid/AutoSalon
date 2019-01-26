using AutoSalon.Controllers;
using AutoSalon.Data;
using AutoSalon.Models;
using AutoSalon.Models.ViewModels.ProizvodjacViewModels;
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
    public class UnitTProizvodjacController
    {
        public IHostingEnvironment he;

        //Pomocna klasa za testiranje Index akcije
        public class RowIndex
        {
            public int ProizvodjacID { get; set; }
            public string Naziv { get; set; }
            public string Drzava { get; set; }
            public string SlikaURL { get; set; }
        }


        [TestMethod]
        public void Index_Model_Proizvodjac()
        {


            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            List<Proizvodjac> ocekivani = applicationDbContext.Proizvodjac.Where(x =>x.DrzavaID  == 1).ToList();

            ProizvodjacController pc = new ProizvodjacController(applicationDbContext, he);
            ViewResult vr = pc.Index(1, "") as ViewResult;

            ProizvodjacIndexVM model = vr.Model as ProizvodjacIndexVM;

            Assert.AreEqual(ocekivani.Count, model.Rows.Count);

        }

        [TestMethod]
        public void Index_Model_List_Proizvodjac()
        {

            ApplicationDbContext applicationDbContext = ContextHelper.GetApplicationDbContext();
            ProizvodjacController pc = new ProizvodjacController(applicationDbContext, he);

            List<Proizvodjac> proizvodjaci = applicationDbContext.Proizvodjac.Include(s => s.Drzava).Where(x => x.DrzavaID == 3).ToList();
            List<RowIndex> ocekivani = new List<RowIndex>();

            //Priprema liste ocekivani 
            foreach (Proizvodjac p in proizvodjaci)
            {

                ocekivani.Add(new RowIndex
                {
                    ProizvodjacID = p.ProizvodjacID,
                    Drzava = p.Drzava.Naziv,
                    Naziv = p.Naziv,
                    SlikaURL = p.SlikaURL
                });
            }

            ViewResult vr = pc.Index(3, "") as ViewResult;

            ProizvodjacIndexVM model = vr.Model as ProizvodjacIndexVM;
            List<RowIndex> rezultat = new List<RowIndex>();

            //Priprema liste rezultat 
            foreach (ProizvodjacIndexVM.Row p in model.Rows)
            {

                rezultat.Add(new RowIndex
                {
                    ProizvodjacID = p.ProizvodjacID,
                    Drzava = p.Drzava,
                    Naziv = p.Naziv,
                    SlikaURL = p.SlikaURL
                });
            }


            CollectionAssert.AreEqual(ocekivani, rezultat,
                            Comparer<RowIndex>.Create(
                                (prvi, drugi) => prvi.ProizvodjacID == drugi.ProizvodjacID
                                           && prvi.Naziv == drugi.Naziv
                                           && prvi.Drzava == drugi.Drzava
                                           && prvi.SlikaURL == drugi.SlikaURL ? 0 : 1));
        }
    }
}
