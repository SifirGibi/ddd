using AutoMapper;
using SifirGibiMakina.Dtos.ServiceExpertiz;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class ServiceEkspertizProfile:Profile
    {
        public ServiceEkspertizProfile()
        {
            CreateMap<tbl_Expertiz, CreateServiceExpertizDto>().ReverseMap();
        }
    }
}