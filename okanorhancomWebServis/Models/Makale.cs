//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace okanorhancomWebServis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Makale
    {
        public int MakaleID { get; set; }
        public string KisaIcerikTr { get; set; }
        public string KisaIcerikEn { get; set; }
        public string IcerikTr { get; set; }
        public string IcerikEn { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<int> MakaleYayinSira { get; set; }
        public string RouteTr { get; set; }
        public string RouteEn { get; set; }
    }
}
