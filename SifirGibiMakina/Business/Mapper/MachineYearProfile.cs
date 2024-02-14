using AutoMapper;
using SifirGibiMakina.Dtos.MachineYear;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class MachineYearProfile:Profile
    {
        public MachineYearProfile()
        {
            CreateMap<tbl_MakinaYillar , MachineYearListDto>().ReverseMap();
        }
    }
}