using AutoMapper;
using SifirGibiMakina.Dtos.Expert;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class ExpertProfile:Profile
    {
        public ExpertProfile()
        {
            CreateMap<tbl_MakinaEksper, ExpertListDto>().ReverseMap();
        }
    }
}