using AutoMapper;
using SifirGibiMakina.Dtos.PaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Mapper
{
    public class PaymentLogProfile:Profile
    {
        public PaymentLogProfile()
        {
            CreateMap<tbl_PaymentLog , CreatePaymentLogDto> ().ReverseMap();    
        }
    }
}