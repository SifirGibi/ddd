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
    
    public partial class tbl_ilanEmail
    {
        public int mesaj_ID { get; set; }
        public Nullable<int> makina_ID { get; set; }
        public Nullable<bool> Durum { get; set; }
        public string GonderenAdi { get; set; }
        public string AliciAdi { get; set; }
        public string AliciMail { get; set; }
        public Nullable<int> UygunCheck { get; set; }
        public Nullable<int> GarantiCheck { get; set; }
        public Nullable<int> DurumuCheck { get; set; }
        public Nullable<int> PazarlikChek { get; set; }
        public string FiyatOneri { get; set; }
        public Nullable<int> DahaFazlaResimChek { get; set; }
        public Nullable<int> YasadigimYerCheck { get; set; }
        public string YasadigimYer { get; set; }
        public Nullable<int> KonusulanDillerCheck { get; set; }
        public string KonusulanDiller { get; set; }
        public Nullable<int> GorusmePlanlamaCheck { get; set; }
        public Nullable<int> IletimTalepCheck { get; set; }
        public Nullable<int> DahaOnceGorusmeCheck { get; set; }
        public string TelefonDahaOnceGorusmeTarih { get; set; }
        public Nullable<int> AyirtmaCheck { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Mesaj { get; set; }
        public string IP { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
        public Nullable<int> FiyatOgreneBilirmiyimCheck { get; set; }
    }
}