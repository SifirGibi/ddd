using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.UserMembership
{
    public class UserPaymentListDto
    {
        public Nullable<int> UserID { get; set; }
        public Nullable<int> MembershipID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
     
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public string PaymentPlanName { get; set; }




      
        public string MembershipVersion { get; set; }

        public string MembershipName { get; set; }
        public Nullable<int> MaxAds { get; set; }

       
    }
}