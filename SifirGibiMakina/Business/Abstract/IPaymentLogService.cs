using SifirGibiMakina.Dtos.PaymentLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IPaymentLogService
    {
         void CreatePaymentog(CreatePaymentLogDto logDto);
    }
}