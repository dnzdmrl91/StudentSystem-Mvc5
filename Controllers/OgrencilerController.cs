using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;


namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {



        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Ogrenciler
        public ActionResult Index()
        {

            var ogrenciler = db.TBLOGRENCI.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {

            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }
                                                 ).ToList();

            ViewBag.dgr = degerler;


            List<SelectListItem> cinsiyet = (from i in db.TBLOGRENCI.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.OGRCINSIYET,
                                                 Value = i.OGRCINSIYET.ToString()
                                             }
                                             ).ToList();

            ViewBag.cns = cinsiyet;


            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(TBLOGRENCI p)
        {

            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            db.TBLOGRENCI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

            var ogrenci = db.TBLOGRENCI.Find(id);
            db.TBLOGRENCI.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {

            var ogrenciler = db.TBLOGRENCI.Find(id);
            return View("OgrenciGetir", ogrenciler);
        }

        public ActionResult Guncelle(TBLOGRENCI p)
        {

            var ogrenciler = db.TBLOGRENCI.Find(p.OGRENCIID);
            ogrenciler.OGRAD = p.OGRAD;
            ogrenciler.OGRSOYAD = p.OGRSOYAD;
            ogrenciler.OGRFOTO = p.OGRFOTO;
            ogrenciler.OGRCINSIYET = p.OGRCINSIYET;
            ogrenciler.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}