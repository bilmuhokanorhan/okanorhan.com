using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace okanorhan.com.Models
{
    public class HomePageView
    {
        public List<WebServices.Yeteneklerim> Yetenekelerim { get; set; }

        public List<WebServices.Kariyer> Kariyer { get; set; }
        public List<WebServices.Yeteneklerim> Hakkimda { get; set; }
        public List<WebServices.Yeteneklerim> İletisim { get; set; }


    }
}