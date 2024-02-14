using AutoMapper;
using SifirGibiMakina.Dtos.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class SocialMediaProfile:Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<tbl_SosyalMedya, SocialMediaListDto>().ReverseMap();
        }
    }
}