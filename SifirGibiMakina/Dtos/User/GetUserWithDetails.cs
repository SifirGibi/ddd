using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.User
{
    public class GetUserWithDetailsDto
    {
       
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string EMail { get; set; }
        public string Adres { get; set; }
        public string Ulke { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string TCK { get; set; }
        public string Sifre { get; set; }
        public string FirmaAdi { get; set; }
        public string Telefon { get; set; }
        public string Hesap_Turu { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public string ServiceUserLogo { get; set; }
        public string ServiceUserBigLogo { get; set; }
        public string ServiceDescriptionTr { get; set; }
        public string CountryName { get; set; }
   



    }
}