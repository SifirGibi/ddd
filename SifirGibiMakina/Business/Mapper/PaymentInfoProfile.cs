using AutoMapper;
using SifirGibiMakina.Dtos.PaymentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class PaymentInfoProfile:Profile
    {
        public PaymentInfoProfile()
        {
            CreateMap<tbl_PaymentInfo,CreatePaymentInfoDto>().ReverseMap(); 
        }
    }
}