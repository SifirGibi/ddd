using AutoMapper;
using SifirGibiMakina.Dtos.MachineBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class MachineBrandProfile:Profile
    {
        public MachineBrandProfile()
        {
            CreateMap<tbl_MakinaMarkalari, MachineBrandListDto>().ReverseMap();
        }
    }
}