using AutoMapper;
using SifirGibiMakina.Dtos.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace SifirGibiMakina.Business.Mapper
{
    public class CountryProfile:Profile
    {
        public CountryProfile()
        {
            CreateMap<tbl_Ulkeler, CountryListDto>().ReverseMap();
        }
    }
}