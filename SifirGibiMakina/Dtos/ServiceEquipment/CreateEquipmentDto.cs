using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceEquipment
{
    public class CreateEquipmentDto
    {
        public string ServiceEquipmentDetailName { get; set; }
        public int ServiceUserID { get; set; }
    }
}