using AutoMapper;
using SifirGibiMakina.Dtos.SubsReturnPaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class SubsReturnPaymentLogProfile:Profile
    {
        public SubsReturnPaymentLogProfile()
        {
            CreateMap<tbl_SubsReturnPaymentLog , CreateSubsReturnPaymentLogDto>().ReverseMap();
        }
    }
}