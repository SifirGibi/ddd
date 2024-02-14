using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Machine
{
    public class MachineCreateDto
    {

        public string Baslik { get; set; }
        public string BaslikEN { get; set; }
        public string BaslikDE { get; set; }
        public string BaslikRU { get; set; }

        public Nullable<int> tur_ID { get; set; }
        public Nullable<int> Alttur_ID { get; set; }
        public Nullable<int> Alttur2_ID { get; set; }

        public Nullable<int> marka_ID { get; set; }
        public Nullable<int> yil_ID { get; set; }

        public Nullable<int> Statu { get; set; } = 1;
        public Nullable<int> Kimden { get; set; } = 3;
        public Nullable<bool> Slide { get; set; } = false;
        public Nullable<bool> Ihale { get; set; } = false;

        public Nullable<bool> Vitrin { get; set; }
     
        public string Model { get; set; }
        public Nullable<int> Fiyat { get; set; } = 0;
        public Nullable<int> Para_Birimi { get; set; }

        public string Aciklama { get; set; }
        public string AciklamaEN { get; set; }
        public string AciklamaDE { get; set; }
        public string AciklamaRU { get; set; }

        public Nullable<bool> SosyalMedyaPaylasim { get; set; }
        public Nullable<int> dil_ID { get; set; } = 1;
        public Nullable<int> Ust_FirmaID { get; set; } = 1;
        public Nullable<int> Firma_ID { get; set; } = 1;
        public Nullable<bool> Yayinda { get; set; } = false;
        public Nullable<bool> Durum { get; set; } = true;

        public Nullable<int> Ekleyen { get; set; }
        public string IP { get; set; }

        public Nullable<DateTime> Kayit_Tarihi { get; set; } = DateTime.Now;

        public string Satis_Temsilcisi_Adi { get; set; }
        public string Satis_Temsilcisi_Telefon { get; set; }
        public string Satis_Temsilcisi_Email { get; set; }

        public string QRCode { get; set; }

        public Nullable<bool> EksperTalebi { get; set; } = false;

      

        public Nullable<int> Ulke { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }

        public string IlanNo { get; set; }

        public Nullable<bool> FiyatGosterilmesin { get; set; }
        public string SEOUrl { get; set; }
        public string SEOUrlEN { get; set; }
        public string SEOUrlDE { get; set; }
        public string SEOUrlRU { get; set; }






   

        //makine Detay
   
    
   

    }
    
   
}