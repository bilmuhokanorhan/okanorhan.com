using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace okanorhancomAdmin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string KullaniciAdi, string Sifre)
        {


            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            var uye = Veri.UyeList().FirstOrDefault(x => x.KullaniciAdi == KullaniciAdi && x.Sifre == Sifre);
            if (uye != null)
            {
                if (uye.Yetki == 0)
                {
                    ViewBag.Hata = "Sisteme Giriş Yetkiniz Bulunmamaktadır.";
                    return View();
                }

                Session["Rol"] = uye.Yetki;
                Session["KullaniciAdi"] = uye.KullaniciAdi;
                return RedirectToAction("Bilgilendirme", "Admin");//giriş sonrası sayfa yönlendirme...


            }
            ViewBag.Hata = "Kullanıcı Adı veya Şifre Hatalıdır.";
            return View();

        }
    }
}