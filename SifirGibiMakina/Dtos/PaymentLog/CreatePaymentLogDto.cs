using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.PaymentLog
{
    public class CreatePaymentLogDto
    {
     
        public string PaymentConversationId { get; set; }
        public Nullable<int> MerchantId { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }
        public string IyziReferenceCode { get; set; }
        public string IyziEventType { get; set; }
        public string IyziEventTime { get; set; }
        public string IyziPaymentId { get; set; }
    }
}