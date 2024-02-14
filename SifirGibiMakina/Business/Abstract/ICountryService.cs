using SifirGibiMakina.Dtos.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface ICountryService
    {
        List<CountryListDto> GetListAllCountry();
        tbl_Ulkeler GetCountry(int id);
    }
}