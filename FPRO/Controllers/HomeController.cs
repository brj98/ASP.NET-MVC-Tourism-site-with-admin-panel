using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FPRO.Models.Class;

namespace FPRO.Controllers
{
    public class HomeController : Controller
    {
        Context DB = new Context();

        // GET: Home
        public ActionResult Index()
        {
            var deger = DB.Blogs.ToList();
            return View(deger);
        }
        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact k)
        {
            DB.Contacts.Add(k);
            DB.SaveChanges();
            return RedirectToAction("Contact");
        }
        public ActionResult Blog()
        {
            var deger = DB.Blogs.ToList();
            return View(deger);
        }
        public ActionResult Otellerimiz()
        {
            var deger = DB.Oteller.ToList();
            return View(deger);
        }
        public ActionResult Restoranlarimiz()
        {
            var deger = DB.Restoranlar.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Uyeler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uyeler(Uyeler k)
        {
            DB.Uyeler.Add(k);
            DB.SaveChanges();
            return RedirectToAction("UyeGiris");
        }
        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeGiris(Uyeler GelenUye)
        {
            Uyeler uye = DB.Uyeler.Where(s => s.Eposta == GelenUye.Eposta && s.Sifre == GelenUye.Sifre).FirstOrDefault();
            if (uye != null)
            {
                FormsAuthentication.SetAuthCookie(GelenUye.Eposta, false);
                Session["uye"] = GelenUye.Eposta;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.hata = "E-Posta yada Şifre yanlış, Lütfen tekrer deneyin";
                return View();
            }
        }

        public ActionResult partial1()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            List<Uyeler> uye = DB.Uyeler.Where(s => s.Eposta == GirenUye).ToList();
            return PartialView(uye);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index" , "Home");
        }

        public ActionResult Profil()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            List<Uyeler> uye = DB.Uyeler.Where(s => s.Eposta == GirenUye).ToList();
            return View(uye);
        }
       
    }
   
}