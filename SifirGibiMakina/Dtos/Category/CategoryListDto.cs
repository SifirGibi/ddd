using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Category
{
    public class CategoryListDto
    {
        public int tur_ID { get; set; }

        public string Kategori { get; set; }
        public string Resim { get; set; }
        public Nullable<bool> Vitrin { get; set; }
        //public int UrunSayisi { get; set; } 
        public  List<tbl_MakinaAltTurleri> tbl_MakinaAltTurleris { get; set; }
        public List<tbl_MakinaAltTurleri2> tbl_MakinaAlt2Turleris { get; set; }
    }
}