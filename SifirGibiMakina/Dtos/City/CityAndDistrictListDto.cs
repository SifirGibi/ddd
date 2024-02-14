using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.City
{
    public class CityAndDistrictListDto
    {
        public int SehirId { get; set; }
        public string SehirAdi { get; set; }
        public List<Ilceler> ilcelers { get; set; }
    }
}