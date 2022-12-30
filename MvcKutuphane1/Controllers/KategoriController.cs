using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcKutuphane1.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1(); // kütüphane entites içindee bulunan tablolara ve proplara erişmemizi sağlıcak.
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.ToList();  // tablo içindek verileri listeleyip tablo formatında döndürecek.
            return View(degerler);
        }
        [HttpGet] //sadece sayfa yüklendiğinde
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost] //sayfa üzerinde bir işlem yaparsak 
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}