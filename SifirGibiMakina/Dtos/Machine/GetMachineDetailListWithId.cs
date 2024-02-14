using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Machine
{
    public class GetMachineDetailListWithIdDto
    {
        public int makina_ID { get; set; }
        public Nullable<int> tur_ID { get; set; }
        public Nullable<int> Alttur_ID { get; set; }
        public Nullable<int> Alttur2_ID { get; set; }
        public Nullable<System.DateTime> Ihale_Baslangic { get; set; }
        public string AltTur { get; set; }
        public Nullable<int> marka_ID { get; set; }
        public string Baslik { get; set; }
        public Nullable<int> SpecificType { get; set; }
        public string Tur { get; set; }
        public string Model { get; set; }
        public Nullable<int> Makina_Order { get; set; }
        public string Marka { get; set; }
        public Nullable<int> Yil { get; set; }
        public Nullable<int> yearID { get; set; }
        public Nullable<int> Fiyat { get; set; }
        public Nullable<int> Para_Birimi { get; set; }
        public string Fotograf { get; set; }
        public Nullable<bool> FiyatGosterilmesin { get; set; }
        public Nullable<System.DateTime> Yayinlanma_Tarihi { get; set; }
        public string SEOUrl { get; set; }
        public Nullable<bool> AnaVitrin { get; set; }
        public Nullable<bool> Vitrin { get; set; }
        public Nullable<bool> Ihale { get; set; }
        public Nullable<System.DateTime> Ihale_Bitis { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
        public Nullable<int> Statu { get; set; }
        public string Aciklama { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public string Satis_Temsilcisi_Adi { get; set; }
        public string Satis_Temsilcisi_Telefon { get; set; }
        public string Satis_Temsilcisi_Email { get; set; }
        public string Kapora { get; set; }
        public string KM { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public Nullable<int> GoruntulenmeSayisi { get; set; }
        public string IlanNo { get; set; }
        public Nullable<int> Kimden { get; set; }
        public int Ekleyen { get; set; }
        public int Ulke { get; set; }
        public Nullable<int> TelefonNumarasiGostermeSayisi { get; set; }
        public Nullable<int> DailyPrice { get; set; }
        public Nullable<int> WeeklyPrice { get; set; }
        public Nullable<int> MonthlyPrice { get; set; }
    }
}