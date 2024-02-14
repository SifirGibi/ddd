using AutoMapper;
using SifirGibiMakina.Dtos.MachineDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class MachineDetailProfile:Profile
    {
        public MachineDetailProfile()
        {
            CreateMap<tbl_MachineDetail , MachineDetailCreateDto>().ReverseMap();
        }
    }
}