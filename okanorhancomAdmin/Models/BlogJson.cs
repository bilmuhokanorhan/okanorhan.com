using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace okanorhancomAdmin.Models
{
    public class BlogJson
    {
        public string KisaIcerikTr { get; set; }
        public string KisaIcerikEn { get; set; }
        public string IcerikTr { get; set; }
        public string IcerikEn { get; set; }
        public System.Web.HttpPostedFileBase Image { get; set; }
        public int  Aktif { get; set; }
        public int MakaleYayinSira { get; set; }
    }
}