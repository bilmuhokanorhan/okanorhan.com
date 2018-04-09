using okanorhancomWebServis.Models;
using okanorhancomWebServis.ModelsView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace okanorhancomWebServis
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://okanorhan.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod(Description = "Yetenek Eklemek için Kullanılacak metod")]
        public bool YeteneklerimCreate(string Yetenek, int YetenekYuzde, int Aktif)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Yeteneklerim Kayit = new Yeteneklerim();
                Kayit.Yetenek = Yetenek;
                Kayit.YetenekYuzde = YetenekYuzde;
                Kayit.Aktif = Durum;
                db.Yeteneklerim.Add(Kayit);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public bool YeteneklerimEdit(int YetenekID, string Yetenek, int YetenekYuzde, int Aktif)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Yeteneklerim Edit = db.Yeteneklerim.Find(YetenekID);
                Edit.Yetenek = Yetenek;
                Edit.YetenekYuzde = YetenekYuzde;
                Edit.Aktif = Durum;
                db.Entry(Edit).State = EntityState.Modified;
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public bool YeteneklerimDelete(int YetenekID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Yeteneklerim Delete = db.Yeteneklerim.Find(YetenekID);
                db.Yeteneklerim.Remove(Delete);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public List<Yeteneklerim> YeteneklerimList()
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                return db.Yeteneklerim.ToList();
            }
        }
        [WebMethod]
        public bool KariyerCreate(string IcerikTr, string IcereikEn, string BaslikTr, int Aktif)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Kariyer Kayit = new Kariyer();
                Kayit.IcerikTr = IcerikTr;
                Kayit.IcerikEn = IcereikEn;
                Kayit.BaslikTr = BaslikTr;
                Kayit.Aktif = Durum;
                db.Kariyer.Add(Kayit);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public bool KariyerEdit(int KariyerID, string IcerikTr, string IcerikEn, string BaslikTr, int Aktif)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Kariyer Edit = db.Kariyer.Find(KariyerID);
                Edit.IcerikTr = IcerikTr;
                Edit.IcerikEn = IcerikEn;
                Edit.BaslikTr = BaslikTr;
                Edit.Aktif = Durum;
                db.Entry(Edit).State = EntityState.Modified;
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public bool KariyerDelete(int KariyerID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Kariyer Delete = db.Kariyer.Find(KariyerID);
                db.Kariyer.Remove(Delete);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public List<Kariyer> KariyerList()
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                return db.Kariyer.ToList();
            }
        }
        [WebMethod]
        [SoapDocumentMethod]

        public bool MakaleCreate(string KisaIcerikTr, string KisaIcerikEn, string IcerikTr, string IcerikEn, string Image, int Aktif, int MakaleYayinSira,string RouteTr)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Makale Kayit = new Makale();
                Kayit.KisaIcerikTr = KisaIcerikTr;
                Kayit.KisaIcerikEn = KisaIcerikEn;
                Kayit.IcerikTr = IcerikTr;
                Kayit.IcerikEn = IcerikEn;
                Kayit.Tarih = DateTime.Now;
                Kayit.Image = Image;
                Kayit.Aktif = Durum;
                Kayit.MakaleYayinSira = MakaleYayinSira;
                Kayit.RouteTr = RouteTr;
                db.Makale.Add(Kayit);
                db.SaveChanges();



            }
            var result = true;
            return result;
        }
        [WebMethod]
        [SoapDocumentMethod]

        public bool MakaleEdit(int MakaleID, string KisaIcerikTr, string KisaIcerikEn, string IcerikTr, string IcerikEn, string Image, int Aktif, int MakaleYayinSira,string RouteTr)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Makale Edit = db.Makale.Find(MakaleID);
                Edit.KisaIcerikTr = KisaIcerikTr;
                Edit.KisaIcerikEn = KisaIcerikEn;
                Edit.IcerikTr = IcerikTr;
                Edit.IcerikEn = IcerikEn;
                Edit.Tarih = DateTime.Now;
                Edit.Image = Image;
                Edit.MakaleID = MakaleID;
                Edit.Aktif = Durum;
                Edit.MakaleYayinSira = MakaleYayinSira;
                Edit.RouteTr = RouteTr;

                db.Entry(Edit).State = EntityState.Modified;
                db.SaveChanges();
            }
            var result = true;
            return result;

        }
        [WebMethod]
        [SoapDocumentMethod]
        public bool MakaleDelete(int MakaleID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Makale Delete = db.Makale.Find(MakaleID);
                db.Makale.Remove(Delete);
                db.SaveChanges();

            }
            var result = true;
            return result;

        }
        [WebMethod]

        public List<Makale> MakaleList()
        {

            using (var db = new okanorhancomBlogDB())
            {
                return db.Makale.ToList();
            }
        }
        [WebMethod]
        [SoapDocumentMethod]
        public bool YorumCreate(int MakaleID, string Baslik, string Yorum, int Aktif)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Yorumlar Kayit = new Yorumlar();
                Kayit.Baslik = Baslik;
                Kayit.Yorum = Yorum;
                Kayit.Tarih = DateTime.Now;
                Kayit.MakaleID = MakaleID;
                Kayit.Tarih = DateTime.Now;
                Kayit.Aktif = Durum;
                db.Yorumlar.Add(Kayit);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        [SoapDocumentMethod]
        public bool YorumEdit(int MakaleID, int YorumID, string Baslik, string Yorum, int Aktif)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Yorumlar Edit = db.Yorumlar.Find(YorumID);
                Edit.Baslik = Baslik;
                Edit.Yorum = Yorum;
                Edit.Tarih = DateTime.Now;
                Edit.MakaleID = MakaleID;
                Edit.Aktif = Durum;
                db.Entry(Edit).State = EntityState.Modified;
                db.SaveChanges();
            }
            var result = true;
            return result;

        }
        [WebMethod]
        public bool YorumDelete(int YorumID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Yorumlar Delete = db.Yorumlar.Find(YorumID);
                db.Yorumlar.Remove(Delete);
                db.SaveChanges();

            }
            var result = true;
            return result;

        }
        [WebMethod]
        [SoapDocumentMethod]
        public List<Yorumlar> YorumList()
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                return db.Yorumlar.ToList();
            }
        }
        [WebMethod]
        public bool UyeCreate(string KullaniciAdi, string Sifre, int Yetki, string Ad, string Soyad, string Email, int Aktif, string Image,string Yas,string Adres, string Telefon)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Uye Kayit = new Uye();
                Kayit.KullaniciAdi = KullaniciAdi;
                Kayit.Sifre = Sifre;
                Kayit.Yetki = Yetki;
                Kayit.Ad = Ad;
                Kayit.Soyad = Soyad;
                Kayit.Email = Email;
                Kayit.Aktif = Durum;
                Kayit.Image = Image;
                Kayit.Yas = Yas;
                Kayit.Adres = Adres;
                Kayit.Telefon = Telefon;
                db.Uye.Add(Kayit);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]

        public bool UyeEdit(string KullaniciAdi, string Sifre, int Yetki, string Ad, string Soyad, string Email, int Aktif, int KayitID, string Yas, string Adres, string Telefon)
        {
            Boolean Durum = Convert.ToBoolean(Aktif);

            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Uye Edit = db.Uye.Find(KayitID);
                Edit.KullaniciAdi = KullaniciAdi;
                Edit.Sifre = Sifre;
                Edit.Yetki = Yetki;
                Edit.Ad = Ad;
                Edit.Soyad = Soyad;
                Edit.Email = Email;
                Edit.Aktif = Durum;
                Edit.Yas = Yas;
                Edit.Adres = Adres;
                Edit.Telefon = Telefon;
                db.Entry(Edit).State = EntityState.Modified;
                db.SaveChanges();
            }
            var result = true;
            return result;

        }
        [WebMethod]
        public bool UyeDelete(int KayitID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Uye Delete = db.Uye.Find(KayitID);
                db.Uye.Remove(Delete);
                db.SaveChanges();

            }
            var result = true;
            return result;

        }

        [WebMethod]
        public List<Uye> UyeList()
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                return db.Uye.ToList();
            }
        }
        [WebMethod]
        public bool DosyaCreate(string SavePath)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Dosyalar Kayit = new Dosyalar();
                Kayit.DosyaPath = SavePath;
                db.Dosyalar.Add(Kayit);
                db.SaveChanges();
            }
            var result = true;
            return result;
        }
        [WebMethod]
        public bool DosyaDelete(int DosyaID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Dosyalar Delete = db.Dosyalar.Find(DosyaID);
                db.Dosyalar.Remove(Delete);
                db.SaveChanges();

            }
            var result = true;
            return result;

        }
        [WebMethod]
        public List<Dosyalar> DosyaList()
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                return db.Dosyalar.ToList();
            }
        }

        [WebMethod]

        public MakaleYorumView MakaleYorumList()
        {
            MakaleYorumView Veri = new MakaleYorumView();
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                Veri.MakaleView = db.Makale.ToList();
                Veri.YorumView = db.Yorumlar.ToList();

                
            }
            return Veri;
        }
        [WebMethod]
        public List<Yorumlar> MakaleYorumDetails(int MakaleID)
        {
            using (okanorhancomBlogDB db = new okanorhancomBlogDB())
            {
                var query = from c in db.Yorumlar

                            where c.MakaleID == MakaleID

                            select c;
                return query.ToList();

            }
        }


    }
}
