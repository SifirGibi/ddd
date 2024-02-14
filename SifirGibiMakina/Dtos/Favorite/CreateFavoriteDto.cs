using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Favorite
{
    public class CreateFavoriteDto
    {
   
        public Nullable<int> makina_ID { get; set; }
        public Nullable<int> user_ID { get; set; }
        public string IP { get; set; }
        public string EklenenFiyat { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
    }
}