using SifirGibiMakina.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Logo
{
    public class CompanyLogoListDto:IDto
    {
        public int logo_ID { get; set; }
        public string Baslik { get; set; }
        public string Fotograf { get; set; }
        public string Link { get; set; }
        //public Nullable<int> Siralama { get; set; }
        public Nullable<int> uye_ID { get; set; }
    }
}