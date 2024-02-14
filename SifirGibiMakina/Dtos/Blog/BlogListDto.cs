using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Blog
{
    public class BlogListDto
    {
         public int duy_ID { get; set; }
        
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Fotograf { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public Nullable<bool> SosyalMedyaPaylasim { get; set; }
        public string KisaAciklama { get; set; }
    }
}