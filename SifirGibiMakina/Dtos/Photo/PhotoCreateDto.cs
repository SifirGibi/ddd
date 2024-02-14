using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Photo
{
    public class PhotoCreateDto
    {


        public string Fotograf { get; set; }
        public Nullable<bool> Durum { get; set; } = true;

        public Nullable<int> makina_ID { get; set; }
   
        public Nullable<bool> Vitrin { get; set; }
        public Nullable<System.DateTime> Kayit_Tarihi { get; set; }
    }
}