using AutoMapper;
using SifirGibiMakina.Dtos.Logo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class CompanyLogoProfile:Profile
    {
        public CompanyLogoProfile()
        {
            CreateMap<tbl_FirmaLogolari , CompanyLogoListDto>().ReverseMap();
        }
    }
}