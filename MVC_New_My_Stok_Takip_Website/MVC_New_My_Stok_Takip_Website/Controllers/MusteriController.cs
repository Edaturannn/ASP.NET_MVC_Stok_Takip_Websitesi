using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_New_My_Stok_Takip_Website.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_New_My_Stok_Takip_Website.Controllers
{
    public class MusteriController : Controller
    {
        MVC_VERİTABANİEntities Db = new MVC_VERİTABANİEntities();
        public ActionResult Index(int? sayfa)
        {
            //var MusteriDeger = Db.musteriler.ToList();
            var MusteriDeger = Db.musteriler.ToList().ToPagedList(sayfa ?? 1, 3);
            return View(MusteriDeger);
        }
        public ActionResult Sil(int id)
        {
            var MusteriDeger = Db.musteriler.Find(id);
            Db.musteriler.Remove(MusteriDeger);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(musteriler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            var MusteriDeger = Db.musteriler.Add(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var MusteriDeger = Db.musteriler.Find(id);
            return View("MusteriGuncelle", MusteriDeger);
        }
        public ActionResult Guncelle(musteriler p)
        {
            var MusteriDeger = Db.musteriler.Find(p.MUSTERIID);
            MusteriDeger.MUSTERIAD = p.MUSTERIAD;
            MusteriDeger.MUSTERISOYAD = p.MUSTERISOYAD;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}