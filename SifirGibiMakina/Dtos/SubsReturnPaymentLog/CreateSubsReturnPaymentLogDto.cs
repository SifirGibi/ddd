using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.SubsReturnPaymentLog
{
    public class CreateSubsReturnPaymentLogDto
    {
        public string SubsLogOrderReferenceCode { get; set; }
        public string SubsLogCustomerReferenceCode { get; set; }
        public string SubsLogSubscriptionReferenceCode { get; set; }
        public string SubsLogIyziReferenceCode { get; set; }
        public string SubsLogIyziEventType { get; set; }
        public string SubsLogIyziEventTime { get; set; }
    }
}