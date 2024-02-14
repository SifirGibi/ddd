using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.User
{
    public class CreateUserDto
    {

   
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string EMail { get; set; }
        public string Hesap_Turu { get; set; }
        public string Cinsiyet { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string IP { get; set; }
        public string Il { get; set; }
        public string FirmaAdi { get; set; }
        public string KayitOlunanSite { get; set; }
        public string Ulke { get; set; }
        public Nullable<int> CountryID { get; set; }



    }

  
   
}