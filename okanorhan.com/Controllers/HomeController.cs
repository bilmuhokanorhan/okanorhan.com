using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace okanorhan.com.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebServices.WebService Veri = new WebServices.WebService();
            Models.HomePageView ViewVeri = new Models.HomePageView();
            ViewVeri.Yetenekelerim = Veri.YeteneklerimList().ToList();
            var KariyerReverse = Veri.KariyerList().OrderByDescending(x => x.KariyerID);
            ViewVeri.Kariyer = KariyerReverse.ToList();
            
            return View(ViewVeri);
        }

       public ActionResult Blog()
        {
            return View();
        }

    }

}
