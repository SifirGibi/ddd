//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SifirGibiMakina
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_DuyurularCat
    {
        public int cat_ID { get; set; }
        public string Kategori { get; set; }
        public string Resim { get; set; }
        public Nullable<bool> Durum { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
        public Nullable<int> Firma_ID { get; set; }
        public Nullable<int> Ust_FirmaID { get; set; }
        public Nullable<int> dil_ID { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
    }
}
