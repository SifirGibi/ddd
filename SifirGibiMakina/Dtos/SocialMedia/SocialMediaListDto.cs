using SifirGibiMakina.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.SocialMedia
{
    public class SocialMediaListDto:IDto
    {
        public string Baslik { get; set; }
        public string FontAwasome { get; set; }
        public string Resim { get; set; }
        public string Link { get; set; }
        public Nullable<int> Siralama { get; set; }
    }
}