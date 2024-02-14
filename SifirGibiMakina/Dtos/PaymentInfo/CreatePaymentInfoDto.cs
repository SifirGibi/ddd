using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.PaymentInfo
{
    public class CreatePaymentInfoDto
    {
  
        public Nullable<int> PaymentId { get; set; }
        public string ConversationId { get; set; }
        public string Status { get; set; }
        public Nullable<int> UserId { get; set; }
        public string BinNumber { get; set; }
        public string PaidPrice { get; set; }
        public string PaymentTransactionId { get; set; }
    }
}