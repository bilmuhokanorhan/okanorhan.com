using okanorhancomAdmin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace okanorhancomAdmin.Controllers
{
    public class AdminController : Controller
    {
        // Bilgilendirme 77

        public ActionResult Bilgilendirme()
        {
            Session["SayfaAdi"] = "Bilgilendirme";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.KariyerList());
        }

        // KARİYER //
        public ActionResult KariyerList()
        {
            Session["SayfaAdi"] = "KariyerListesi";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.KariyerList());
        }
        public ActionResult KariyerCreate()
        {
            Session["SayfaAdi"] = "KariyerEkle";

            return View();

        }
        [ValidateInput(false)]

        [HttpPost]
        public JsonResult KariyerCreate(string IcerikTr,string IcerikEn,string BaslikTr,int Aktif)
        {
            Session["SayfaAdi"] = "KariyerEkle";
            if (IcerikTr.Length > 0 && IcerikEn.Length>0&& BaslikTr.Length>0)
            {
                AdminWebServis.WebService Veri = new AdminWebServis.WebService();
                Veri.KariyerCreate(IcerikTr, IcerikEn, BaslikTr, Aktif);
                return Json("Yükleme İşlemi Başarılı...");

            }
            return Json("Yükleme Sırasında Hata Oluştu.Tekrar Deneyiniz...");


        }
        [ValidateInput(false)]

        public JsonResult KariyerEditDetails(int? KariyerID)
        {
            Session["SayfaAdi"] = "KariyerEdit";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            var KariyerList = Veri.KariyerList();
            var sonuc = KariyerList.Where(x => x.KariyerID == KariyerID).FirstOrDefault();
            return Json(sonuc);
        }
        [ValidateInput(false)]

        [HttpPost]
        public JsonResult KariyerEdit(string IcerikTr, string IcerikEn, string BaslikTr, int Aktif,int KariyerID)
        {
            Session["SayfaAdi"] = "KariyerEdit";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.KariyerEdit(KariyerID,IcerikTr, IcerikEn, BaslikTr, Aktif);
            return Json("Yükleme İşlemi Başarılı...");
        }

        public JsonResult KariyerDelete(int KariyerID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.KariyerDelete(KariyerID);
            return Json("Silme İşlemi Başarılı...");
        }

        // Yeteneklerim //
        public ActionResult YeteneklerimList()
        {
            Session["SayfaAdi"] = "YeteneklerimListesi";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.YeteneklerimList());
        }
        public ActionResult YeteneklerimCreate()
        {
            Session["SayfaAdi"] = "YeteneklerimEkle";

            return View();

        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult YeteneklerimCreate(string Yetenek, int Yuzde,int Aktif)
        {
            Session["SayfaAdi"] = "YeteneklerimEkle";

            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.YeteneklerimCreate(Yetenek, Yuzde, Aktif);
            return RedirectToAction("../Admin/YeteneklerimList");

        }
        [ValidateInput(false)]

        public ActionResult YeteneklerimEdit(int? YetenekID)
        {
            Session["SayfaAdi"] = "YeteneklerimEdit";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            var YeteneklerimList = Veri.YeteneklerimList();
            var sonuc = YeteneklerimList.Where(x => x.YetenekID == YetenekID).FirstOrDefault();
            return View(sonuc);
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult YeteneklerimEdit(string Yetenek, int Yuzde, int Aktif, int YetenekID)
        {
            Session["SayfaAdi"] = "YeteneklerimEdit";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.YeteneklerimEdit(YetenekID,Yetenek, Yuzde, Aktif);
            return RedirectToAction("../Admin/YeteneklerimList");
        }

        public ActionResult YeteneklerimDelete(int YetenekID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.YeteneklerimDelete(YetenekID);
            return RedirectToAction("../Admin/YeteneklerimList");
        }
        // Uye //

        public ActionResult UyeList()
        {
            Session["SayfaAdi"] = "UyeListesi";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.UyeList());
        }
        public ActionResult UyeCreate()
        {
            Session["SayfaAdi"] = "UyeEkle";

            return View();

        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult UyeCreate(string KullaniciAdi, string Sifre, int Yetki, string Ad, string Soyad, string Email, int Aktif, System.Web.HttpPostedFileBase Image,string Yas,string Telefon,string Adres)
        {
            Session["SayfaAdi"] = "UyeEkle";

            string GuidKey = Guid.NewGuid().ToString();
            string dosyaYolu = GuidKey + ".png";
            var yuklemeYeri = Path.Combine(Server.MapPath("~/Dosyalar/"), dosyaYolu);
            Image.SaveAs(yuklemeYeri);
            var SaveImage = "/Dosyalar/" + dosyaYolu;

            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.UyeCreate(KullaniciAdi, Sifre, Yetki, Ad, Soyad, Email, Aktif, SaveImage,Yas,Adres,Telefon);
            return RedirectToAction("../Admin/UyeList");

        }
        [ValidateInput(false)]

        public ActionResult UyeEdit(int? KayitID)
        {
            Session["SayfaAdi"] = "UyeEdit";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            var UyeList = Veri.UyeList();
            var sonuc = UyeList.Where(x => x.KayitID == KayitID).FirstOrDefault();
            return View(sonuc);
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult UyeEdit(string KullaniciAdi, string Sifre, int Yetki, string Ad, string Soyad, string Email, int Aktif,int KayitID, string Yas, string Telefon, string Adres)
        {
        

            Session["SayfaAdi"] = "UyeEdit";

            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.UyeEdit(KullaniciAdi, Sifre, Yetki,  Ad, Soyad, Email, Aktif, KayitID, Yas, Adres, Telefon);
            return RedirectToAction("../Admin/UyeList");
        }

        public ActionResult UyeDelete(int KayitID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.UyeDelete(KayitID);
            return RedirectToAction("../Admin/UyeList");
        }
        // Dosyalar //

        public ActionResult Dosyalar()
        {
            Session["SayfaAdi"] = "Dosyalar";

            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.DosyaList());

        }
        [HttpPost]

        public JsonResult FileUploadAjax(System.Web.HttpPostedFileBase Dosya)
        {
            if (Dosya != null)
            {
                AdminWebServis.WebService Veri = new AdminWebServis.WebService();
                if (!Path.GetExtension(Dosya.FileName).Equals(".png"))
                {
                    return base.Json("Yanlış dosya tipi!Lütfen Png Formatında Yükleme Yapınız!");

                }
                string GuidKey = Guid.NewGuid().ToString();

                string dosyaYolu = GuidKey + ".png";
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Dosyalar"), dosyaYolu);
                Dosya.SaveAs(yuklemeYeri);
                var SavePath = "/Dosyalar/" + dosyaYolu;

                Veri.DosyaCreate(SavePath);
                return Json("Resim Sisteme Yüklenmiştir...", JsonRequestBehavior.AllowGet);

            }
            return Json("Yükleme Sırasında Hata Oluştu!!!", JsonRequestBehavior.AllowGet);
        }
        public ActionResult DosyaDelete(int DosyaID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.DosyaDelete(DosyaID);

            return RedirectToAction("Dosyalar", "Admin");

        }

        // Blog //
        
        public ActionResult MakaleList()
        {
            Session["SayfaAdi"] = "MakaleListesi";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.MakaleList());
        }
        public ActionResult MakaleListJson()
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return Json(Veri.MakaleList(), JsonRequestBehavior.AllowGet);

            
        }
        public ActionResult MakaleCreate()
        {
            Session["SayfaAdi"] = "MakaleCreate";

            return View();

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult MakaleCreate(string KisaIcerikTr, string KisaIcerikEn, string IcerikTr, string IcerikEn, System.Web.HttpPostedFileBase Image, int Aktif, int MakaleYayinSira,string RouteTr)
        {

            string GuidKey = Guid.NewGuid().ToString();
            string dosyaYolu = GuidKey + ".png";
            var yuklemeYeri = Path.Combine(Server.MapPath("~/Dosyalar/"), dosyaYolu);
            Image.SaveAs(yuklemeYeri);
            var SaveImage = "/Dosyalar/" + dosyaYolu;

            Session["SayfaAdi"] = "MakaleCreate";

            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.MakaleCreate(KisaIcerikTr,KisaIcerikEn, IcerikTr, IcerikEn, SaveImage,Aktif,MakaleYayinSira,RouteTr);
            return RedirectToAction("../Admin/MakaleList");

        }

        public ActionResult MakaleEdit(int? MakaleID)
        {
            Session["SayfaAdi"] = "MakaleEdit";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            var MakaleList = Veri.MakaleList();
            var sonuc = MakaleList.Where(x => x.MakaleID == MakaleID).FirstOrDefault();
            return View(sonuc);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult MakaleEdit(string KisaIcerikTr, string KisaIcerikEn, string IcerikTr, string IcerikEn, string Image, int Aktif, int MakaleYayinSira,int MakaleID,string RouteTr)
        {
            //string GuidKey = Guid.NewGuid().ToString();
            //string dosyaYolu = GuidKey + ".png";
            //var yuklemeYeri = Path.Combine(Server.MapPath("~/Dosyalar/"), dosyaYolu);
            //Image.SaveAs(yuklemeYeri);
            //var SaveImage = "/Dosyalar/" + dosyaYolu;

            Session["SayfaAdi"] = "MakaleEdit";

            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.MakaleEdit(MakaleID, KisaIcerikTr, KisaIcerikEn, IcerikTr, IcerikEn, Image, Aktif, MakaleYayinSira, RouteTr);
            return RedirectToAction("../Admin/MakaleList");
        }

        public ActionResult MakaleDetails(int MakaleID)
        {

            Session["SayfaAdi"] = "MakaleDetay";
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            var MakaleList = Veri.MakaleList();
            var sonuc = MakaleList.Where(x => x.MakaleID == MakaleID).FirstOrDefault();
            return View(sonuc);
        }
        public ActionResult MakaleDelete(int MakaleID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.MakaleDelete(MakaleID);

            return Json(MakaleID, JsonRequestBehavior.AllowGet);

        }

        public ActionResult MakaleYorumView()
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            return View(Veri.MakaleYorumList());

        }
        public ActionResult MakaleYorumDetails(int MakaleID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();

            var sonuc = Veri.MakaleYorumDetails(MakaleID);
            return Json(sonuc, JsonRequestBehavior.AllowGet);
            

        }
        public ActionResult YorumDelete(int YorumID)
        {
            AdminWebServis.WebService Veri = new AdminWebServis.WebService();
            Veri.YorumDelete(YorumID);
            return Json(true, JsonRequestBehavior.AllowGet);



        }



        public ActionResult Lagout()
        {
            
                Session["Rol"] = null;
                return RedirectToAction("Index", "Login");//giriş sonrası sayfa yönlendirme...

        }
    }
}