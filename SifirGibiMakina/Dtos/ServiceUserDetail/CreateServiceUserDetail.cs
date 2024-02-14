using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceUserDetail
{
    public class CreateServiceUserDetailDto
    {
        public int ServiceUserID { get; set; }

        public string ServiceUserLogo { get; set; }
        public string ServiceUserBigLogo { get; set; }
    }
}