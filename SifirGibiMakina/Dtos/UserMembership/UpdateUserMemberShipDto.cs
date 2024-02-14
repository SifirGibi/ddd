using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.UserMembership
{
    public class UpdateUserMemberShipDto
    {
        public int UserMembershipID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> MembershipID { get; set; }
        public Nullable<int> PaymentPlanID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}