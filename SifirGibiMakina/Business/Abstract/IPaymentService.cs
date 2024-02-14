using SifirGibiMakina.Dtos.PaymentInfo;
using SifirGibiMakina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SifirGibiMakina.Business.Concrete.PaymentManager;

namespace SifirGibiMakina.Business.Abstract
{
    public interface IPaymentService
    {
        ResultPaymentMessage CreatePayment(PaymentModel paymentModel, MemberVersionForBasket memberVersion, PaymentInformation paymentInformation);

        ResultPaymentMessage CreatePaymentSubscriber(PaymentModel paymentModel, MemberVersionForBasket memberVersion, PaymentInformation paymentInformation);



    }
}