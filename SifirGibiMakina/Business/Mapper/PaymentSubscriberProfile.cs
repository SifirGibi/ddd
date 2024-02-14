using AutoMapper;
using SifirGibiMakina.Dtos.PaymentSubscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class PaymentSubscriberProfile:Profile
    {
        public PaymentSubscriberProfile()
        {
            CreateMap<tbl_PaymentSubscriber , CreatePaymentSubscriberDto>().ReverseMap();   
        }
    }
}