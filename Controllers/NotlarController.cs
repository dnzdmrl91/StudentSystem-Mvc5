using OgrenciNotMvc.Models;
using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Notlar
        public ActionResult Index()
        {

            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        

        [HttpGet]
        public ActionResult YeniNot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniNot(TBLNOTLAR p)
        {

            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var notlar = db.TBLNOTLAR.Find(id);
            return View("NotGetir", notlar);
        }


        [HttpPost]
        public ActionResult NotGetir(Islem isl,TBLNOTLAR p, int sinav1=0, int sinav2=0, int sinav3=0, int proje=0)
        {

            if(isl.islemler=="Hesapla")
            {
                double ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if(isl.islemler =="NotGuncelle")
            {
                var notlar = db.TBLNOTLAR.Find(p.NOTID);
                notlar.SINAV1 = p.SINAV1;
                notlar.SINAV2 = p.SINAV2;
                notlar.SINAV3 = p.SINAV3;
                notlar.PROJE = p.PROJE;
                notlar.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}