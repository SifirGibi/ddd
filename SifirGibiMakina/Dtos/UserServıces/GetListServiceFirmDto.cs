using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.UserServıces
{
    public class GetListServiceFirmDto
    {

        public int uye_ID { get; set; }
        public string FirmName { get; set; }
        public string FirmDescription { get; set;}
        public string Address { get; set; }
        public string FirmLogo { get; set; }
     


        public Nullable<int> SubCategoryID { get; set; }
        public Nullable<int> SubSubCategoryID { get; set; }   

    }
}