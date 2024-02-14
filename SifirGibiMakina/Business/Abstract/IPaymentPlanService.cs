using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IPaymentPlanService
    {
        void CreatePaymentProduct();
        void CreatePaymentPlanForPaymentProduct();
        string GetPaymentPlanRefenceCode(int versionId);
    }
}