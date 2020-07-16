using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {



        DbMvcOkulEntities db = new DbMvcOkulEntities();

        // GET: Default
        public ActionResult Index()
        {

            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return View();
        }


        public ActionResult Sil(int id)
        {
            var dersler = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(dersler);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DersGetir(int id)
        {

            var dersler = db.TBLDERSLER.Find(id);
            return View("DersGetir",dersler);
        }

        public ActionResult Guncelle(TBLDERSLER p)
        {
            var dersler = db.TBLDERSLER.Find(p.DERSID);
            dersler.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}