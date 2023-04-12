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
    public class KategoriController : Controller
    {
        MVC_VERİTABANİEntities Db = new MVC_VERİTABANİEntities();
        public ActionResult Index(int? sayfa)
        {
            //var KategoriDegeri = Db.kategoriler.ToList();
            var KategoriDegeri = Db.kategoriler.ToList().ToPagedList(sayfa ?? 1, 3);
            return View(KategoriDegeri);
        }
        public ActionResult Sil(int id)
        {
            var KategoriDegeri = Db.kategoriler.Find(id);
            Db.kategoriler.Remove(KategoriDegeri);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> KategoriDegeri = (from i in Db.kategoriler.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.KATEGORIAD,
                                                       Value = i.KATEGORIAD.ToString()
                                                   }
                                                 ).ToList();
            ViewBag.dgr = KategoriDegeri;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(kategoriler p)
        {
            var KategoriDegeri = Db.kategoriler.Add(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGuncelle(int id)
        {
            var KategoriDegeri = Db.kategoriler.Find(id);
            return View("KategoriGuncelle", KategoriDegeri);
        }
        public ActionResult Guncelle(kategoriler p)
        {
            var KategoriDegeri = Db.kategoriler.Find(p.KATEGORIID);
            KategoriDegeri.KATEGORIAD = p.KATEGORIAD;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}