using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace okanorhancomWebServis.ModelsView
{
    public class MakaleYorumView
       
    {
        public List <okanorhancomWebServis.Models.Makale> MakaleView { get; set; }
        public List<okanorhancomWebServis.Models.Yorumlar> YorumView { set; get; }
    }
}