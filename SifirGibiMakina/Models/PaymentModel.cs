using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Models
{
    public class PaymentModel
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonht { get; set; }
        public string ExpireYear { get; set; }
        public string Cvc  { get; set; }
        public Nullable<int> Installment { get; set; }
        public bool RegisterCard { get; set; }  
        public string Price { get; set; }
        public string ProductReferenceCode { get; set; }    

    }
}