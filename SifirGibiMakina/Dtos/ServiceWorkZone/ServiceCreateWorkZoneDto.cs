using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceWorkZone
{
    public class ServiceCreateWorkZoneDto
    {
        public int ServiceUserID { get; set; }
        public int ServiceWorkZonceCountyID { get; set; }
    }
}