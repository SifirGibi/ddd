using SifirGibiMakina.Dtos.PaymentSubscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IPaymentSubscriberService
    {
     
        void GetSubsriber(string subsCode, bool status);
    }
}