using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.PaymentSubscriber
{
    public class CreatePaymentSubscriberDto
    {
  
        public Nullable<int> SubscriberUserId { get; set; }
        public string SubscriberRefenceCode { get; set; }
        public string SubscriberParentReferenceCode { get; set; }
        public string SubscriberPricingPlanReferenceCode { get; set; }
        public string SubscriberCustomerReferenceCode { get; set; }
        public string SubscriberSubscriptionStatus { get; set; }
        public Nullable<DateTime> SubscriberCreatedDate { get; set; }
        public Nullable<DateTime> SubscriberStartDate { get; set; }

        public Nullable<int> SubscriberPaymentProdcutPayPlanId { get; set; }
        public bool IsActive { get; set; }  
    }
}