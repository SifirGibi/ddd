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
    
    public partial class tbl_BeniHaberdarEt
    {
        public int benihaberdaret_ID { get; set; }
        public string AdSoyad { get; set; }
        public string EMail { get; set; }
        public string Telefon { get; set; }
        public Nullable<int> tur_ID { get; set; }
        public Nullable<int> Alttur_ID { get; set; }
        public Nullable<int> Alttur2_ID { get; set; }
        public Nullable<int> marka_ID { get; set; }
        public Nullable<int> yil_ID { get; set; }
        public string Model { get; set; }
        public string Fiyat { get; set; }
        public Nullable<int> Para_Birimi { get; set; }
        public string Aciklama { get; set; }
        public string Rapor { get; set; }
        public Nullable<bool> Yanit { get; set; }
        public Nullable<bool> Durum { get; set; }
        public Nullable<int> Ekleyen { get; set; }
        public string IP { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
        public Nullable<System.DateTime> Rapor_Tarihi { get; set; }
    }
}
