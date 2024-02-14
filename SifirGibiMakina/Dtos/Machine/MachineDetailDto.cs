using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Machine
{
    public class MachineDetailDto
    {
        public int makina_ID { get; set; }
        public Nullable<int> tur_ID { get; set; }
        public string Baslik { get; set; }

        public string TurAdı { get; set; }

        public string MarkaAdı { get; set; }
        public Nullable<int> MachineYear { get; set; }
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
    }
}