using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AyHesapDokumu.Models;

namespace AyHesapDokumu.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var tumAylarWm = new TumAylarWiewModel();
            using (var db = new SiteContext())
            {
                tumAylarWm.GelirGiderList = db.GelirGider.Include("Aylar").ToList();
                tumAylarWm.AylarList = db.Aylar.ToList();
            }
            foreach (var t in tumAylarWm.AylarList)
            {
                foreach (var t1 in tumAylarWm.GelirGiderList)
                {
                    if (t1.Gelirmi && t1.Aylar.AylarId == t.AylarId)
                        t.ToplamGelir += Convert.ToInt32(t1.Tutar);
                    else if (t1.Gelirmi == false && t1.Aylar.AylarId == t.AylarId)
                        t.ToplamGider += Convert.ToInt32(t1.Tutar);
                }
            }
            return View(tumAylarWm);
        }

        /// <summary>
        /// Hesaps this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Hesap()
        {
            var gelirGiderAyWm = new GelirGiderAyWiewModel();
            using (var db = new SiteContext())
            {
                gelirGiderAyWm.AylarList = db.Aylar.ToList();
            }
            ViewBag.seciliAy = TempData["seciliAy"] ?? 0;
            return View(gelirGiderAyWm);
        }

        /// <summary>
        /// Hesaps the specified gelir gider ay wm.
        /// </summary>
        /// <param name="gelirGiderAyWm">The gelir gider ay wm.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hesap(GelirGiderAyWiewModel gelirGiderAyWm)
        {
            using (var db = new SiteContext())
            {
                var ay = db.Aylar.FirstOrDefault(x => x.AylarId == gelirGiderAyWm.GelirGider.AylarId);
                gelirGiderAyWm.GelirGider.Aylar = ay;
                db.GelirGider.Add(gelirGiderAyWm.GelirGider);
                db.SaveChanges();
            }
            TempData["seciliAy"] = gelirGiderAyWm.GelirGider.AylarId;
            return RedirectToAction("Hesap");
        }

        /// <summary>
        /// Gelirs the gider sil.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GelirGiderSil(int id)
        {
            var giderAylarId = default(int);
            using (var context = new SiteContext())
            {
                var gelirGider = context.GelirGider.FirstOrDefault(x => x.GelirgiderId == id);
                if (gelirGider != null)
                {
                    giderAylarId = gelirGider.AylarId;
                    context.GelirGider.Remove(gelirGider);
                }

                context.SaveChanges();
            }
            TempData["seciliAy"] = giderAylarId;

            return RedirectToAction("Hesap");
        }

        /// <summary>
        /// Gelirs the gider duzenle.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GelirGiderDuzenle(int id)
        {
            GelirGider gelirGider;
            using (var context = new SiteContext())
            {
                gelirGider = context
                    .GelirGider
                    .Include("Aylar")
                    .FirstOrDefault(x => x.GelirgiderId == id);
            }

            return View(gelirGider);
        }

        /// <summary>
        /// Gelirs the gider duzenle.
        /// </summary>
        /// <param name="gelirGider">The gelir gider.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GelirGiderDuzenle(GelirGider gelirGider)
        {
            using (var context = new SiteContext())
            {
                var gelirgiderDefault = context
                    .GelirGider
                    .FirstOrDefault(x => x.GelirgiderId == gelirGider.GelirgiderId);

                if (gelirgiderDefault != null)
                {
                    gelirgiderDefault.Aciklama = gelirGider.Aciklama;
                    gelirgiderDefault.Tutar = gelirGider.Tutar;
                    gelirgiderDefault.OnemDerecesi = gelirGider.OnemDerecesi;
                }

                context.SaveChanges();
            }
            TempData["seciliAy"] = gelirGider.AylarId;

            return RedirectToAction("Hesap");
        }

        /// <summary>
        /// Aies this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Ay()
        {
            var ayWiewModel = new AyWiewModel();
            List<Aylar> ayList;
            using (var context = new SiteContext())
            {
                ayList = context.Aylar.ToList();
            }
            ayWiewModel.AylarList = ayList;

            return View(ayWiewModel);
        }

        /// <summary>
        /// Aies the specified ay.
        /// </summary>
        /// <param name="ay">The ay.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ay(AyWiewModel ay)
        {
            using (var context = new SiteContext())
            {
                context.Aylar.Add(ay.Aylar);
                context.SaveChanges();
            }

            return RedirectToAction("Ay");
        }

        /// <summary>
        /// Aies the sil.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AySil(int id)
        {
            using (var context = new SiteContext())
            {
                var aylar = context.Aylar.FirstOrDefault(x => x.AylarId == id);
                if (aylar != null)
                {
                    context.Aylar.Remove(aylar);
                }
                context.SaveChanges();
            }

            return RedirectToAction("Ay");
        }

        /// <summary>
        /// Aies the duzenle.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AyDuzenle(int id)
        {
            Aylar aylar;
            using (var context = new SiteContext())
            {
                aylar = context.Aylar.FirstOrDefault(x => x.AylarId == id);
            }

            return View(aylar);
        }

        /// <summary>
        /// Aies the duzenle.
        /// </summary>
        /// <param name="ay">The ay.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AyDuzenle(Aylar ay)
        {
            using (var db = new SiteContext())
            {
                var aylar = db.Aylar.FirstOrDefault(x => x.AylarId == ay.AylarId);
                if (aylar != null)
                {
                    aylar.AyAdi = ay.AyAdi;
                    aylar.OnemDerecesi = ay.OnemDerecesi;
                }

                db.SaveChanges();
            }

            return RedirectToAction("Ay");
        }

        /// <summary>
        /// Hesaps the ac re.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public JsonResult HesapAcRe(int id)
        {
            using (var db = new SiteContext())
            {
                var model = db.GelirGider.Include("Aylar").Where(x => x.Aylar.AylarId == id).ToList();

                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
    }
}