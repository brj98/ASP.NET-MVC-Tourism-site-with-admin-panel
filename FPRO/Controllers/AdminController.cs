using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FPRO.Models.Class;

namespace FPRO.Controllers
{
    public class AdminController : Controller
    {
        Context DB = new Context();
        // GET: Admin
        [Authorize]
        public ActionResult AdminSayfasi()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            List<Admin> uye = DB.Admins.Where(s => s.Kulanciadi == GirenUye).ToList();
            return View(uye);
        }
        [Authorize]

        public ActionResult Geziler()
        {
            var deger = DB.Blogs.ToList();
            return View(deger);
        }
        [Authorize]
        public ActionResult MessageList()
        {
            var deger = DB.Contacts.ToList();
            return View(deger);
        }
        public ActionResult Sil(int id)
        {
            var MeS = DB.Contacts.Find(id);
            DB.Contacts.Remove(MeS);
            DB.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [Authorize]
        public ActionResult Uyelerq()
        {
            var deger = DB.Uyeler.ToList();
            return View(deger);
        }
        public ActionResult UyeSil(int id)
        {
            var MeS = DB.Uyeler.Find(id);
            DB.Uyeler.Remove(MeS);
            DB.SaveChanges();
            return RedirectToAction("Uyelerq");
        }
        public ActionResult BlogSil(int id)
        {
            var MeS = DB.Blogs.Find(id);
            DB.Blogs.Remove(MeS);
            DB.SaveChanges();
            return RedirectToAction("Geziler");
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog k)
        {
            if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                k.Resim = "/Image/" + dAdi + duzanti;
            }
            DB.Blogs.Add(k);
            DB.SaveChanges();
            return RedirectToAction("Geziler");
        }
        [Authorize]

        public ActionResult GeziDuzelt(int id)
        {

            Blog ro = null;
            if (ro != null)
            {
                ro = DB.Blogs.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(ro);
        }

        [HttpPost]
        public ActionResult GeziDuzelt(int? id, Blog model)
        {

            int sonuc = 0;
            Blog ro = DB.Blogs.Where(x => x.ID == id).FirstOrDefault();
            if (ro != null)
            {

                ro.Baslik = model.Baslik;
                ro.Aciklama = model.Aciklama;
                sonuc = DB.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Geziler");
            }
            else
            {
                return View();
            }

        }
        /*--------------------------------------------------------------------*/
        [Authorize]

        public ActionResult Oteller()
        {
            var deger = DB.Oteller.ToList();
            return View(deger);
        }
        [Authorize]

        [HttpGet]
        public ActionResult Yeniotel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeniotel(Oteller t)
        {
            if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                t.Resim = "/Image/" + dAdi + duzanti;
            }
            DB.Oteller.Add(t);
            DB.SaveChanges();
            return RedirectToAction("Oteller");
        }
        public ActionResult OtellSil(int id)
        {
            var MeS = DB.Oteller.Find(id);
            DB.Oteller.Remove(MeS);
            DB.SaveChanges();
            return RedirectToAction("Oteller");
        }
        [Authorize]

        public ActionResult OtelDuzelt(int id)
        {                                                 

            Oteller ro = null;
            if (ro != null)
            {
                ro = DB.Oteller.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(ro);
        }

        [HttpPost]
        public ActionResult OtelDuzelt(int? id, Oteller model)
        {

            int sonuc = 0;
            Oteller ro = DB.Oteller.Where(x => x.ID == id).FirstOrDefault();
            if (ro != null)
            {


                ro.Aciklama = model.Aciklama;
                ro.Baslik = model.Baslik;
                ro.Bilgi = model.Bilgi;
                ro.Fiyat = model.Fiyat;


                sonuc = DB.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Oteller");
            }
            else
            {
                return View();
            }

        }
        /*--------------------------------------------------------------------*/
        [Authorize]

        public ActionResult Restoranlar()
        {
            var deger = DB.Restoranlar.ToList();
            return View(deger);
        }
        [Authorize]

        [HttpGet]
        public ActionResult YeniRestoran()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniRestoran(Restoranlar t)
        {
            if (Request.Files.Count > 0)
            {
                string dAdi = Path.GetFileName(Request.Files[0].FileName);
                string duzanti = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Image/" + dAdi + duzanti;
                Request.Files[0].SaveAs(Server.MapPath(url));
                t.Resim = "/Image/" + dAdi + duzanti;
            }
            DB.Restoranlar.Add(t);
            DB.SaveChanges();
            return RedirectToAction("Restoranlar");
        }
        public ActionResult ResSil(int id)
        {
            var MeS = DB.Restoranlar.Find(id);
            DB.Restoranlar.Remove(MeS);
            DB.SaveChanges();
            return RedirectToAction("Restoranlar");
        }
        [Authorize]

        public ActionResult ResDuzelt(int id)
        {

            Restoranlar ro = null;
            if (ro != null)
            {
                ro = DB.Restoranlar.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(ro);
        }

        [HttpPost]
        public ActionResult ResDuzelt(int? id, Restoranlar model)
        {

            int sonuc = 0;
            Restoranlar ro = DB.Restoranlar.Where(x => x.ID == id).FirstOrDefault();
            if (ro != null)
            {


                ro.Aciklama = model.Aciklama;
                sonuc = DB.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Restoranlar");
            }
            else
            {
                return View();
            }

        }
        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/
        [Authorize]
        public ActionResult Adminler()
        {
            var deger = DB.Admins.ToList();
            return View(deger);
        }
        [Authorize]
        public ActionResult AdmDuzelt(int id)
        {

            Admin ro = null;
            if (ro != null)
            {
                ro = DB.Admins.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(ro);
        }

        [HttpPost]
        public ActionResult AdmDuzelt(int? id, Admin model)
        {

            int sonuc = 0;
            Admin ro = DB.Admins.Where(x => x.ID == id).FirstOrDefault();
            if (ro != null)
            {


                ro.AdiSoyad = model.AdiSoyad;
                ro.Kulanciadi = model.Kulanciadi;
                ro.Sifre = model.Sifre;
                ro.Eposta = model.Eposta;


                sonuc = DB.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Adminler");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AdmSil(int id)
        {
            var MeS = DB.Admins.Find(id);
            DB.Admins.Remove(MeS);
            DB.SaveChanges();
            return RedirectToAction("Adminler");
        }

        /*\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logina", "Login");
        }

    }


}