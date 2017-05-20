using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AyHesapDokumu.Models;

namespace AyHesapDokumu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TumAylarWM tumAylarWm = new TumAylarWM();
            using (SiteContext db = new SiteContext())
            {
                tumAylarWm.GelirGiderList = db.GelirGider.Include("Aylar").ToList();
                tumAylarWm.AylarList = db.Aylar.ToList();
            }
            foreach (Aylar t in tumAylarWm.AylarList)
            {
                foreach (GelirGider t1 in tumAylarWm.GelirGiderList)
                {
                    if (t1.Gelirmi && t1.Aylar.AylarId == t.AylarId)
                        t.ToplamGelir += Convert.ToInt32(t1.Tutar);
                    else if (t1.Gelirmi == false && t1.Aylar.AylarId == t.AylarId)
                        t.ToplamGider += Convert.ToInt32(t1.Tutar);
                }
            }
            return View(tumAylarWm);
        }

        public ActionResult Hesap()
        {
            GelirGiderAyWM gelirGiderAyWm = new GelirGiderAyWM();
            using (SiteContext db = new SiteContext())
            {
                gelirGiderAyWm.AylarList = db.Aylar.ToList();
            }
            ViewBag.seciliAy = TempData["seciliAy"] ?? 0;
            return View(gelirGiderAyWm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hesap(GelirGiderAyWM gelirGiderAyWm)
        {
            using (SiteContext db = new SiteContext())
            {
                var ay = db.Aylar.FirstOrDefault(x => x.AylarId == gelirGiderAyWm.GelirGider.AylarId);
                gelirGiderAyWm.GelirGider.Aylar = ay;
                db.GelirGider.Add(gelirGiderAyWm.GelirGider);
                db.SaveChanges();
            }
            TempData["seciliAy"] = gelirGiderAyWm.GelirGider.AylarId;
            return RedirectToAction("Hesap");
        }


        public ActionResult GGSil(int id)
        {
            int ayid = 0;
            using (var db =new SiteContext())
            {
                GelirGider gg = db.GelirGider.FirstOrDefault(x => x.GelirgiderId == id);
                ayid = gg.AylarId;
                db.GelirGider.Remove(gg);
                db.SaveChanges();
            }
            TempData["seciliAy"] = ayid;
            return RedirectToAction("Hesap");
        }


        public ActionResult GGDuzenle(int id)
        {
            var gg =new GelirGider();
            using (var db=new SiteContext())
            {
                 gg = db.GelirGider.Include("Aylar").FirstOrDefault(x => x.GelirgiderId == id);
            }

            return View(gg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GGDuzenle(GelirGider gelirGider)
        {
            GelirGider gelirgiderDefault =new GelirGider();
            using (var db = new SiteContext())
            {
                gelirgiderDefault = db.GelirGider.FirstOrDefault(x => x.GelirgiderId == gelirGider.GelirgiderId);
                gelirgiderDefault.Aciklama = gelirGider.Aciklama;
                gelirgiderDefault.Tutar = gelirGider.Tutar;
                gelirgiderDefault.OnemDerecesi = gelirGider.OnemDerecesi;
                db.SaveChanges();
            }

            TempData["seciliAy"] = gelirGider.AylarId;
            return RedirectToAction("Hesap");
        }

        public ActionResult Ay()
        {
            AyWM aylarWm = new AyWM();
            List<Aylar> ayList;
            using (var _db = new SiteContext())
            {
                ayList = _db.Aylar.ToList();
            }
            aylarWm.AylarList = ayList;
            return View(aylarWm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ay(AyWM ay)
        {
            using (SiteContext _db = new SiteContext())
            {
                _db.Aylar.Add(ay.Aylar);
                _db.SaveChanges();
            }
            return RedirectToAction("Ay");
        }


        public ActionResult AySil(int id)
        {
            using (var db = new SiteContext())
            {
                var aylar = db.Aylar.FirstOrDefault(x => x.AylarId == id);
                if (aylar != null)
                    db.Aylar.Remove(aylar);
                db.SaveChanges();
            }
            return RedirectToAction("Ay");
        }

        public ActionResult AyDuzenle(int id)
        {
            Aylar aylar = new Aylar();
            using (var db = new SiteContext())
            {
                aylar = db.Aylar.FirstOrDefault(x => x.AylarId == id);
            }
            return View(aylar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AyDuzenle(Aylar ay)
        {
            Aylar aylar = new Aylar();
            using (var db = new SiteContext())
            {
                aylar = db.Aylar.FirstOrDefault(x => x.AylarId == ay.AylarId);
                aylar.AyAdi = ay.AyAdi;
                aylar.OnemDerecesi = ay.OnemDerecesi;
                db.SaveChanges();
            }
            return RedirectToAction("Ay");
        }


        public JsonResult HesapAcRe(int id)
        {
            using (SiteContext db = new SiteContext())
            {
                var model = db.GelirGider.Include("Aylar").Where(x => x.Aylar.AylarId == id).ToList();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
    }
}