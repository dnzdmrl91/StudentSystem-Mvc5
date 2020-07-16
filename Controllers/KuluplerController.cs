using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {


        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulupler
        public ActionResult Index()
        {

            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KulupEkle(TBLKULUPLER p)
        {

            
            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {

            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {

            var kulupler = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulupler);
        }

        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var kulupler = db.TBLKULUPLER.Find(p.KULUPID);
            kulupler.KULUPAD = p.KULUPAD;
            kulupler.KULUPKONTENJAN = p.KULUPKONTENJAN;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}