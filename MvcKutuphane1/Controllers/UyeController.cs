using MvcKutuphane1.Models.Entity;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using PagedList;
using PagedList.Mvc;
namespace MvcKutuphane1.Controllers

{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);
            //var degerler = db.TBLUYELER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var usr = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var usr = db.TBLUYELER.Find(id);
            return View("UyeGetir", usr);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var usr = db.TBLUYELER.Find(p.ID);
            usr.AD = p.AD;
            usr.SOYAD = p.SOYAD;
            usr.MAIL = p.KULLANICIADI;
            usr.KULLANICIADI = p.KULLANICIADI;
            usr.SIFRE = p.SIFRE;
            usr.OKUL = p.OKUL;
            usr.TELEFON = p.TELEFON;
            usr.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult UyeKitapGecmis(int id)
        //{
        //    var ktpgcms = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
        //    var uyekit = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
        //    ViewBag.u1 = uyekit;
        //    return View(ktpgcms);
        //}

    }
}