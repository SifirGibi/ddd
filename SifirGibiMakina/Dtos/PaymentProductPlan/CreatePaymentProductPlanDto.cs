using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.PaymentProductPlan
{
    public class CreatePaymentProductPlanDto
    {
      
        public string PaymentProductStatus { get; set; }
        public string PaymnetProductReferenceCode { get; set; }
        public Nullable<DateTime> PaymentProductCreatedDate { get; set; }
        public string PaymentProductName { get; set; }
        public Nullable<int> PaymentVersionId { get; set; }
     
    }
}