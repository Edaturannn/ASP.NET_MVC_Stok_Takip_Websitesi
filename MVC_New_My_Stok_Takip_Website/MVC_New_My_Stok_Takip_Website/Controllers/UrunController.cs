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
    public class UrunController : Controller
    {
        MVC_VERİTABANİEntities Db = new MVC_VERİTABANİEntities();
        public ActionResult Index(int? sayfa)
        {
            //var UrunDegeri = Db.urunler.ToList();
            var UrunDegeri = Db.urunler.ToList().ToPagedList(sayfa ?? 1, 3);
            return View(UrunDegeri);
        }
        public ActionResult Sil(int id)
        {
            var UrunDegeri = Db.urunler.Find(id);
            Db.urunler.Remove(UrunDegeri);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(urunler p)
        {
            var UrunDegeri = Db.urunler.Add(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGuncelle(int id)
        {
            var UrunDegeri = Db.urunler.Find(id);
            return View("UrunGuncelle", UrunDegeri);
        }
        public ActionResult Guncelle(urunler p)
        {
            var UrunDegeri = Db.urunler.Find(p.URUNID);
            UrunDegeri.URUNAD = p.URUNAD;
            UrunDegeri.MARKA = p.MARKA;
            UrunDegeri.URUNKATEGORI = p.URUNKATEGORI;
            UrunDegeri.FIYAT = p.FIYAT;
            UrunDegeri.STOK = p.STOK;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}