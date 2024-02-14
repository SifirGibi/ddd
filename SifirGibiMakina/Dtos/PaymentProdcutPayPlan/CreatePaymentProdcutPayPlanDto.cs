using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.PaymentProdcutPayPlan
{
    public class CreatePaymentProdcutPayPlanDto
    {

        public string PaymentProdcutPayPlanName { get; set; }
        public string PaymentProdcutPayPlanReferenceCode { get; set; }
        public Nullable<int> PaymentProdcutPayPlanPrice { get; set; }
        public string PaymentProdcutPayCurrencyCode { get; set; }
        public string PaymentProdcutPayPaymentInterval { get; set; }
        public Nullable<int> PaymentProdcutPayPaymentIntervalCount { get; set; }
        public Nullable<int> PaymentProdcutPayRecurrenceCount { get; set; }
        public Nullable<bool> PaymentProdcutPayIsActive { get; set; }
        public Nullable<DateTime> PaymentProdcutPayPlanCreatedDate { get; set; }
        public Nullable<int> PaymentProductPayPlanVersionID { get; set; }

    }
}