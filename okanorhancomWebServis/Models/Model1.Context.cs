﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class okanorhancomBlogDB : DbContext
    {
        public okanorhancomBlogDB()
            : base("name=okanorhancomBlogDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dosyalar> Dosyalar { get; set; }
        public virtual DbSet<Kariyer> Kariyer { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yeteneklerim> Yeteneklerim { get; set; }
        public virtual DbSet<Yorumlar> Yorumlar { get; set; }
    }
}
