using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_New_My_Stok_Takip_Website.Models.Entity;

namespace MVC_New_My_Stok_Takip_Website.Controllers
{
    public class SatisController : Controller
    {
        MVC_VERİTABANİEntities Db = new MVC_VERİTABANİEntities();
        public ActionResult Index()
        {
            var SatisDegeri = Db.satislar.ToList();
            return View(SatisDegeri);
        }
        public ActionResult Sil(int id)
        {
            var SatisDegeri = Db.satislar.Find(id);
            Db.satislar.Remove(SatisDegeri);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(satislar p)
        {
            Db.satislar.Add(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}