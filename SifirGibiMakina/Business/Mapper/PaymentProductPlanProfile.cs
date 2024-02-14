using AutoMapper;
using SifirGibiMakina.Dtos.PaymentProductPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class PaymentProductPlanProfile:Profile
    {
        public PaymentProductPlanProfile()
        {
            CreateMap<tbl_PaymentProduct , CreatePaymentProductPlanDto>().ReverseMap();
        }
    }
}