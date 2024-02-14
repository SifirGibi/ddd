using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceExpertiz
{
    public class CreateServiceExpertizDto
    {
     
        public int ExpertizFirmasi_ID { get; set; }
        public DateTime Randevu_Tarihi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string EMail { get; set; }
        public string Baslik { get; set; }
        public int tur_ID { get; set; }
        public int Alttur_ID { get; set; }
  
        public int marka_ID { get; set; }
        public int yil_ID { get; set; }
        public string Model { get; set; }
        public bool Durum { get; set; } = false;
        public bool Yanit { get; set; } = false;


        public string IP { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }

        public int uye_ID { get; set; }


    }
}