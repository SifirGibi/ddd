using AutoMapper;
using SifirGibiMakina.Dtos.PaymentProdcutPayPlan;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class PaymentProductPayPlanProfile:Profile
    {
        public PaymentProductPayPlanProfile()
        {
            CreateMap<tbl_PaymentProdcutPayPlan,CreatePaymentProdcutPayPlanDto>().ReverseMap();
        }
    }
}