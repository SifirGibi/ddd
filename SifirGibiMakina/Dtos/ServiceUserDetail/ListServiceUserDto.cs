using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceUserDetail
{
    public class ListServiceUserDto
    {

        public int ServiceUserID { get; set; }
        public string FirmName { get; set; }
  
        public string Address { get; set; }
        public string Email { get; set; }



        public Nullable<int> SubCategoryID { get; set; }
        public Nullable<int> CategoryID { get; set; }

        public Nullable<int> CountryID { get; set; }
    }
}