using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.Photo
{
    public class GetListPhotoDto
    {
        public int makinaResim_ID { get; set; }
        public Nullable<int> makina_ID { get; set; }
        public string Fotograf { get; set; }

    }
}
