using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPRO.Models.Class;
using System.Web.Security;

namespace FPRO.Controllers
{
    public class LoginController : Controller
    {
        Context DB = new Context();
        // GET: Login

        public ActionResult Logina()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logina(Admin a)

        {
            var deger = DB.Admins.FirstOrDefault(x => x.Kulanciadi == a.Kulanciadi && x.Sifre == a.Sifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.Kulanciadi, false);

                Session["Kulanciadi"] = deger.Kulanciadi.ToString();
                return RedirectToAction("AdminSayfasi", "Admin");
            }
            else
            {
                ViewBag.hata = "Kullancı Adı yada Şifre yanlış, Lütfen tekrer deneyin";
                return View();
            }

        }
    }
}