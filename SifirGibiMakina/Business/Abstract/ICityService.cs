using SifirGibiMakina.Dtos.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface ICityService
    {
        List<CityAndDistrictListDto> GetAllCityAndDistrict();
    }
}